open System

type IShape =
    abstract member Name: string
    abstract member Area: float

type Circle(radius: float) =
    interface IShape with
        member _.Name = "Circle"
        member _.Area = Math.PI * radius * radius

type Rectangle(width: float, height: float) =
    interface IShape with
        member _.Name = "Rectangle"
        member _.Area = width * height

let shapes: IShape list = [
    Circle 5.0
    Rectangle(4.0, 6.0)
]

shapes 
|> List.iter (fun s -> printfn "%-10s Area: %.2f" s.Name s.Area)
