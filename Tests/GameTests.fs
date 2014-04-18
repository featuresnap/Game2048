module GameTests

open FsUnit
open Xunit
open GameFunctions

[<Fact>]
let ``collapse removes leading zeros``() = 
    [ 0; 2 ]
    |> collapse
    |> should equal [ 2 ]

[<Fact>]
let ``collapse combines two of same value``() = 
    [ 0; 2; 2 ]
    |> collapse
    |> should equal [ 4 ]

[<Fact>]
let ``collapse does not combine two different values``() = 
    [ 0; 2; 4 ]
    |> collapse
    |> should equal [ 2; 4 ]

[<Fact>]
let ``collapse should only combine one level``() = 
    [ 2; 2; 2; 2 ]
    |> collapse
    |> should equal [ 4; 4 ]

[<Fact>]
let ``collapse prefers combining to left``() = 
    [ 2; 2; 2; 4 ]
    |> collapse
    |> should equal [ 4; 2; 4 ]

[<Fact>]
let ``collapse prefers combining to left again``() = 
    [ 4; 2; 2; 2 ]
    |> collapse
    |> should equal [ 4; 4; 2 ]

[<Fact>]
let ``padRightZeros adds zeros to make length the specified value``() = 
    []
    |> padRightZeros 4
    |> should equal [ 0; 0; 0; 0 ]

[<Fact>]
let ``padRightZeros does not exceed specified length``() = 
    [ 2; 4; 8; 16 ]
    |> padRightZeros 4
    |> should equal [ 2; 4; 8; 16 ]
