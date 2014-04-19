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

let makeSwipeLeft n values = 
    values 
    |> collapse
    |> padRightZeros n

let swipeLeft = makeSwipeLeft 4
let swipeRight = List.rev >> swipeLeft >> List.rev

let column n (array:'a[,]) = array.[*, n]
let row n (array:'a[,]) = array.[n,*]

let maxColumnIndex array = Array2D.length2 array - 1
let maxRowIndex array = Array2D.length1 array - 1 
            
let rotateClockwise array = 
    let reverseColumn n (array:'a[,]) = array |> column n |> Array.rev 
    [   for col in 0..(maxColumnIndex array) do 
        yield array |> reverseColumn col ]
    |> array2D   
     
let arrayToRows array = 
    [for r in 0..(maxRowIndex array) do
        yield row r array |> List.ofArray]

let arrayToColumns array =
    [for c in 0..maxColumnIndex array do
        yield column c array |> List.ofArray]

let rowsToArray rows = array2D rows
let columnsToArray columns = columns |> List.rev |>  array2D |>  rotateClockwise

let swipeBoardLeft = arrayToRows >> List.map swipeLeft >> rowsToArray
let swipeBoardRight = arrayToRows >> List.map swipeRight >> rowsToArray
let swipeBoardUp = arrayToColumns >> List.map swipeLeft >> columnsToArray
let swipeBoardDown = arrayToColumns >> List.map swipeRight >> columnsToArray
        
        