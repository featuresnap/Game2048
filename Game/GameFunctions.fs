module GameFunctions

let rec zeros = Seq.initInfinite (fun i -> 0)

let smush acc value = 
    match value, acc with
    |0, _ -> acc
    |_, [] -> [value]
    |n, x::xs -> if n = x then (n+x) :: xs else n::acc

let collapse values = 
    values 
    |> List.fold smush [] 
    |> List.rev  

let padRightZeros targetLength list = 
    Seq.concat [ list; zeros ]
    |> Seq.take targetLength
    |> List.ofSeq

let swipeLeft values = 
    values
    |> collapse
    |> padRightZeros 4

let swipeRight = 
    List.rev
    >> swipeLeft
    >> List.rev


let column n (array:'a[,]) = array.[*, n]

let row n (array:'a[,]) = array.[n,*]