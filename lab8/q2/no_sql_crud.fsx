#r "nuget: MongoDB.Driver"

open MongoDB.Bson
open MongoDB.Bson.Serialization.Attributes
open MongoDB.Driver

type Student = {
    [<BsonId>] Id: int
    Name: string
    Age: int
}

let client = MongoClient("mongodb://localhost:27017")
let db = client.GetDatabase("SchoolDb")
let collection = db.GetCollection<Student>("students")

let createStudent (s: Student) =
    collection.InsertOne(s)

let readStudents () : Student list =
    collection.Find(FilterDefinition<Student>.Empty).ToList() |> Seq.toList

let updateStudent (s: Student) =
    let filter = Builders<Student>.Filter.Eq((fun x -> x.Id), s.Id)
    collection.ReplaceOne(filter, s) |> ignore

let deleteStudent id =
    let filter = Builders<Student>.Filter.Eq((fun x -> x.Id), id)
    collection.DeleteOne(filter) |> ignore

let printStudents label =
    printfn "\n=== NoSQL (MongoDB) - %s ===" label
    match readStudents () with
    | [] -> printfn "No documents found."
    | list -> list |> List.iter (fun s -> printfn "ID: %d | Name: %-12s | Age: %d" s.Id s.Name s.Age)

// Clear existing data for a clean run
db.DropCollection("students")

// Execution
createStudent { Id = 101; Name = "Charlie"; Age = 23 }
createStudent { Id = 102; Name = "Diana"; Age = 24 }
printStudents "After CREATE"

updateStudent { Id = 101; Name = "Charlie Brown"; Age = 24 }
printStudents "After UPDATE"

deleteStudent 102
printStudents "After DELETE"
