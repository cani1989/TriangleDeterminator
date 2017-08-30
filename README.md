# TriangleDeterminator

This solution contains a console applications that takes 3 numbers as input, that matches the dimensions of a triangle. The program will determine the `TriangleType` to be of the types: `Scalene`, `Isosceles` or `Equilateral`. 
Keep in mind that a valid triangle must have valid dimensions i.e. the sum of the 2 shortest sides must be larger than the longest side. If this is not respected, then an exception called `TriangleDimensionException` will be thrown.

The core logic has been placed in an auxilairy class `TriangleExtensions`, that will be used to validate and assist with operations on the main object itself (`Triangle`).

Finally, a `NUnit` test project has been added, which ensures the core logic functions correctly.

# Demo

Run the `.exe` file and follow instructions. 

![Demo](https://raw.githubusercontent.com/cani1989/TriangleDeterminator/master/demo.gif)
