#r "nuget: Microsoft.Data.Sqlite"

open Microsoft.Data.Sqlite

type Student = { Id: int; Name: string; Age: int }

let connStr = "Data Source=students.db"

let executeNonQuery sql parameters =
    using (new SqliteConnection(connStr)) (fun conn ->
        conn.Open()
        using (conn.CreateCommand()) (fun cmd ->
            cmd.CommandText <- sql
            for (name, value: obj) in parameters do
                cmd.Parameters.AddWithValue(name, value) |> ignore
            cmd.ExecuteNonQuery() |> ignore))

let initDb () =
    executeNonQuery 
        "CREATE TABLE IF NOT EXISTS Students (Id INTEGER PRIMARY KEY, Name TEXT, Age INTEGER)" []

let createStudent (s: Student) =
    executeNonQuery 
        "INSERT INTO Students (Id, Name, Age) VALUES (@id, @name, @age)" 
        [ ("@id", s.Id); ("@name", s.Name); ("@age", s.Age) ]

let readStudents () : Student list =
    using (new SqliteConnection(connStr)) (fun conn ->
        conn.Open()
        using (conn.CreateCommand()) (fun cmd ->
            cmd.CommandText <- "SELECT Id, Name, Age FROM Students ORDER BY Id"
            using (cmd.ExecuteReader()) (fun reader ->
                [ while reader.Read() do
                    yield { Id = reader.GetInt32(0); Name = reader.GetString(1); Age = reader.GetInt32(2) } ])))

let updateStudent (s: Student) =
    executeNonQuery 
        "UPDATE Students SET Name = @name, Age = @age WHERE Id = @id" 
        [ ("@name", s.Name); ("@age", s.Age); ("@id", s.Id) ]

let deleteStudent id =
    executeNonQuery "DELETE FROM Students WHERE Id = @id" [ ("@id", id) ]

let printStudents label =
    printfn "\n=== SQL (SQLite) - %s ===" label
    match readStudents () with
    | [] -> printfn "No records found."
    | list -> list |> List.iter (fun s -> printfn "ID: %d | Name: %-12s | Age: %d" s.Id s.Name s.Age)

// Execution
initDb ()
createStudent { Id = 1; Name = "Alice"; Age = 20 }
createStudent { Id = 2; Name = "Bob"; Age = 22 }
printStudents "After CREATE"

updateStudent { Id = 1; Name = "Alice Smith"; Age = 21 }
printStudents "After UPDATE"

deleteStudent 2
printStudents "After DELETE"
