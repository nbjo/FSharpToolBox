module FSharpToolBoxLib

let helloLib name =
    printfn "Hello from FSharpToolBoxLib %s" name

let bind nextFunction twoTrackInput = 
    match twoTrackInput with
    | Ok success -> nextFunction success
    | Error error -> Error error