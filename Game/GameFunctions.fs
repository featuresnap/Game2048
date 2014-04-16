module GameFunctions

let rec shiftLeft values = 
    match values with
    | 0 :: rest -> shiftLeft rest
    | x :: y :: rest -> 
        if x = y then (x + y) :: (shiftLeft rest)
        else x :: (shiftLeft (y :: rest))
    | _ -> values

let padRightZeros targetLength list = 
    let rec zeros = 
        seq { 
            yield 0
            yield! zeros
        }
    Seq.concat [ list; zeros ]
    |> Seq.take targetLength
    |> List.ofSeq

let swipeLeft values = 
    values
    |> shiftLeft
    |> padRightZeros 4

let swipeRight = 
    List.rev
    >> swipeLeft
    >> List.rev
