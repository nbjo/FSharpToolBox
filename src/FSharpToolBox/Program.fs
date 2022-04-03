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

let input = { Name = "Peter Jensen Peter Jensen Peter Jensen Peter Jensen Peter Jensen"; Email = "x@y.com"}

let resultFromValidation = validate input

let print result = printfn "result from validation = %s" result

let printResult result =
    match result with
    | Ok input -> printfn "input = (%s, %s)" input.Name input.Email
    | Error error -> printfn "error = %s" error

printResult resultFromValidation

let logger = new LoggingBuilder()

let loggedWorkflow =
    logger
        {
        let! x = 42
        let! y = 43
        let! z = x + y
        return z
        }

let maybe = new MaybeBuilder()

let divideBy bottom top =
    if bottom = 0
    then None
    else Some(top/bottom)

let divideByWorkflow init x y z =
    maybe
        {
            let! a = init |> divideBy x
            let! b = a |> divideBy y
            let! c = b |> divideBy z
            return c
        }

let good = divideByWorkflow 12 3 2 1

let printDiv (result : option<int>) =
    match result with
    | None -> printfn "Failed!"
    | Some v -> printfn $"result = {v}"

printDiv good

let dictInput = [ (1, "a"); (2, "b") ]

let dict = dictInput |> Map.ofList

let xx = 42