module FSharpToolBoxLib

let helloLib name =
    printfn "Hello from FSharpToolBoxLib %s" name

let bind nextFunction twoTrackInput = 
    match twoTrackInput with
    | Ok success -> nextFunction success
    | Error error -> Error error

type LoggingBuilder() =
    let log p = printfn "expression is %A" p

    member this.Bind(x, f) =
        log x
        f x

    member this.Return(x) =
        x

type MaybeBuilder() =

    member this.Bind(x, f) =
        match x with
        | None -> None
        | Some a -> f a

    member this.Return(x) =
        Some x
