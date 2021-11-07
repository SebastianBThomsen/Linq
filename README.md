# LINQTraining

The intention of this project is to provide examples for practicing LINQ queries.
Included is an sqlite database with a dataset. Below is a class diagram for the models used to create generate the database (with EFC).

![alt text](https://github.com/TroelsMortensen/LINQTraining/blob/master/LINQTraining/ModelsDiagram.png "Models diagram")

Most of the directories are not relevant, they just contain code to generate the data. But the data is already present in the Family.db file. Your task lies in the Exercises.cs file.

# Step 1 – Setup

I have created the model classes, a FamilyContext : DbContext, and an SQLite file for you. It’s all included in the project.

Open the database in the view to verify there’s data in it.

The data model is the same as the assignment, same relationships, though slightly simplified.

 

# Step 2 – Answer questions

You are now going to implement methods, which will query the FamilyContext.Families. There is only one DbSet in the Context: Families. The intent is to only use this set as an access point. I.e. all your queries should start with

```
familyContext.Families…
```

That is, you should not do anything like
```
familyContext.Set<Child>()….
```
That is not the intention, and would make things too easy. It should be a last resort.

 

Find the file “Exercises.cs”. This is a unit test class (again like Fiftyville). Each method is a question you should answer with a query.

 
### Example:

How many families live in a house with the address number 1?

```
public void HowManyFamiliesLiveInNumberOne()
{
    var result = ctx.Families.Where(family => family.HouseNumber == 1).ToList();
    Console.WriteLine(result.Count);
}
```

This method will print out the number of families living in number 1, irrespective of the street name.

For all methods/questions, there is a comment above with my answer.

You have access to the PrettyPrint method again, if you wish to print out the result as a table to verify its correctness. See the example methods in Exercise.cs for usage.

All my solutions can be found in the sub-class to Exercises.cs, it’s in the SolutionExample folder:

  
# Note
It is possible to do all questions without calling ToList() until the end. 

When you call ToList() you get more LINQ methods available, with more allowed logic inside the predicates. So this is sometimes easier, but also less efficient. 
