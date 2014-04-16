module GameTests

open FsUnit
open Xunit

[<Fact>]
let ``TestTrue`` () = 
    true |> should equal true