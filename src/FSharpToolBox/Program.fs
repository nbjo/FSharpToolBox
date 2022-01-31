open FSharpToolBoxLib

type Input = {
    Name : string
    Email : string
}

let nameNotBlank input = 
    if input.Name = "" then
        Error "Name must not be blank"
    else Ok input

let nameLessThan50 input = 
    if input.Name.Length > 50 then
        Error "Name must not be longer than 50 chars"
    else Ok input

let emailNotBlank input = 
    if input.Email = "" then
        Error "Email must not be blank"
    else Ok input

let validate input =
    input
    |> nameNotBlank
    |> bind nameLessThan50
    |> bind emailNotBlank

// For more information see https://aka.ms/fsharp-console-apps
printfn "FSharpToolBox - Begin explore"

// Test using FSharpToolBoxLib
helloLib "Nijo"

let input = { Name = "Peter"; Email = "x@y.com"}

let resultFromValidation = validate input

let print result = printfn "result from validation = %s" result

let printResult result =
    match result with
    | Ok input -> printfn "input = (%s, %s)" input.Name input.Email
    | Error error -> printfn "error = %s" error

printResult resultFromValidation

