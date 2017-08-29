# TriangleDeterminator

This contains a simple console applications that takes 3 numbers as input and determines its `TriangleType`: `Scalene`, `Isosceles` or `Equilateral`. 
Keep in mind that a valid triangle must have valid dimensions i.e. the sum of the 2 shortest sides must be larger than the longest side. This will throw an exception called `TriangleDimensionException`.

The core logic has been placed auxilairy classes in order to validate and assist operations on the main object itself (`Triangle`).

Furthermore, a `NUnit` test project has been added, which ensures the core logic functions correctly.