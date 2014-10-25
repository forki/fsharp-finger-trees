namespace Fingertrees.Tests

open System
open Fingertrees
open NUnit.Framework
open FsCheck
open FsCheck.NUnit
open Monoid

module public TestSumMonoid =

  [<TestFixtureSetUp>]
  let monoid = SumMonoid()

  [<Test>]
  let ``mempty <> x = x`` () =
    Check.QuickThrowOnFailure(
      fun (x: int) ->
        monoid.mappend monoid.mempty x = x)

  [<Test>]
  let ``x <> (y <> z) = (x <> y) <> z`` () =
    Check.QuickThrowOnFailure(
      fun (x: int, y: int, z: int) ->
        monoid.mappend (monoid.mappend x y) z = monoid.mappend x (monoid.mappend y z))

  [<Test>]
  let ``moncat x, y, z = (x <> y) <> z`` () =
    Check.QuickThrowOnFailure(
      fun (x: int, y: int, z: int) ->
        monoid.mconcat [|x; y; z|] = monoid.mappend (monoid.mappend x y) z)
