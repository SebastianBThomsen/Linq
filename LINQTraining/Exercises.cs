﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DataGenerator.Generator;
using LINQTraining.DataAccess;
using LINQTraining.Generator;
using Microsoft.EntityFrameworkCore;
using Models;
using NUnit.Framework;
using static LINQTraining.PrintUtil.Printer;

namespace LINQTraining
{
    [TestFixture]
    public class Exercises
    {
        /**
         * Intro text
         * In this exercise you are supposed to solve all questions using only the ctx.Families entry point to the database.
         * That means if you use e.g. ctx.Set<Child>()... you are taking an unintended shortcut.
         *
         * All questions can be answered with one statement. Though, if you're stuck you may find it easier to break it down
         * into multiple consecutive statements.
         *
         * Again, you have access to the PrettyPrint method. In this case however, it's a bit limited, because it cannot print
         * out nested objects. E.g. a Family have Adults, but that will not be printed out in a neat way.
         *
         * All questions have the correct answer above them in a comment
         */
        protected FamilyContext ctx;

        [SetUp]
        public virtual void Setup()
        {
            ctx = new FamilyContext();
        }

      /*
       [Test]
        public virtual void CreateAndSeed()
        {
            IList<Family> families = new FamilyGenerator().GenerateFamilies(500);
            string famSerialized = JsonSerializer.Serialize(families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            DBSeeder.Seed(families);
        }*/

        // example
        [Test]
        public virtual void NumberOfAdults()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).ToList();
            PrettyPrint(adults);
            int numOfAdults = adults.Count();
            Console.WriteLine(numOfAdults);
        }

        // example
        [Test]
        public virtual void DisplayRedHairedAdultsBetween37And53()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).Where(adult =>
                adult.HairColor.Equals("Red") &&
                adult.Age >= 37 &&
                adult.Age <= 53
            ).ToList();
            PrettyPrint(adults);
            Console.WriteLine(adults.Count());
        }


        // answer: 5
        [Test]
        public virtual void HowManyFamiliesLiveAt()
        {
            int amountOfFamilies = ctx.Families.Count(f => f.StreetName.Equals("Abby Park Street"));

            Assert.AreEqual(5, amountOfFamilies);
            // street "Abby Park Street"
        }


        // answer 151
        [Test]
        public virtual void HowManyFamiliesHaveOneParent()
        {
            int familiesOneParent = ctx.Families.Count(family => family.Adults.Count() == 1);

            Assert.AreEqual(151, familiesOneParent);
            // we are looking for the number families, which have exactly one parent.

        }

        // answer: 123
        [Test]
        public virtual void HowManyFamiliesLiveInNumberThreeOrFive()
        {
            // no matter which street, just focus on house number
            int threeOrFive = ctx.Families.Count(family => family.HouseNumber == 3 || family.HouseNumber == 5);
            
            Assert.AreEqual(123, threeOrFive);

        }


        // answer: 94
        [Test]
        public virtual void HowManyFamiliesHaveADog()
        {
            // one or more dogs
            int familiesWithDog = ctx.Families.Count(family => family.Pets.Any(pet => pet.Species.Contains("Dog")));
            
            Assert.AreEqual(94, familiesWithDog);

        }

        // answer: 18
        [Test]
        public virtual void HowManyFamiliesHaveCatAndDog()
        {
            // one or more of either. But at least one dog, and at least one cat
            int familiesWithDogAndCat = ctx.Families.Count(family => family.Pets.Any(pet => pet.Species.Contains("Dog")) && family.Pets.Any(pet => pet.Species.Contains("Cat")));

            Assert.AreEqual(18, familiesWithDogAndCat);
        }


        // answer 125
        [Test]
        public virtual void HowManyFamiliesHave3Children()
        {
            int familiesWithThreeChildren = ctx.Families.Count(family => family.Children.Count() == 3);
            
            Assert.AreEqual(125,familiesWithThreeChildren);
            // exactly 3 children

        }

        // answer: 175
        [Test]
        public virtual void How_Many_Families_Have_Gay_Parents()
        {
            // looking for families with two parents of the same sex
            // this one is pretty tough in one query, if you don't all ToList() before the end.
            int familiesWithGayParents = ctx.Families.Count(family => family.Adults.Count(adult => adult.Sex.Equals("M")) == 2 ||
                                                                      family.Adults.Count(adult => adult.Sex.Equals("F")) == 2);
            Assert.AreEqual(175, familiesWithGayParents);
            /*
            int familiesWithGayParents = ctx.Families.Count(family => family.Adults.Count() == 2 &&
                                                                      family.Adults.First(
                                                                          adult => adult.Sex.Equals("F")).Equals(
                                                                          family.Adults.Last(adult =>
                                                                              adult.Sex.Equals("F")))
                                                                      || family.Adults.First(
                                                                          adult => adult.Sex.Equals("M")).Equals(
                                                                          family.Adults.Last(adult =>
                                                                              adult.Sex.Equals("M"))));
                                                                      */
                                                                      /*
                                                                      family.Adults.Any(adult => !adult.Sex.Equals("F"))
                                                                      && family.Adults.Any(adult =>
                                                                          !adult.Sex.Equals("M")));
                                                                          */                                                                     
                                                                      
        }


        // answer 21
        [Test]
        public virtual void How_Many_Families_Have_An_Adult_With_Red_Hair()
        {
            int FamilyAdultRedHair =
                ctx.Families.Count(family => family.Adults.Any(adult => adult.HairColor.Equals("Red")));
            Assert.AreEqual(21,FamilyAdultRedHair);
            // count the number of families with at least one adult with red hair.

        }


        // answer: 26
        [Test]
        public virtual void How_Many_Families_Have_2_Pets()
        {
            // Exactly 2 pets. Doesn't matter what type of pet. Ignore the children's pets for this one.
            int FamiliesWithTwoPets = ctx.Families.Count(family => family.Pets.Count() == 2);
            
            Assert.AreEqual(26,FamiliesWithTwoPets);
        }


        // answer: 81
        [Test]
        public virtual void How_Many_Families_Have_A_Child_Playing_Soccer()
        {
            // at least one child.
            int FamiliesWithSoccerChildren =
                ctx.Families.Count(family => family.Children.Any(child => child.Interests.Any(interest => interest.Type.Equals("Soccer"))));
            
            Assert.AreEqual(81, FamiliesWithSoccerChildren);

        }

        // answer: 355
        [Test]
        public virtual void How_Many_Families_Have_Adult_And_Child_With_Black_Hair()
        {
            // count number of families where at least one adult and one child have black hair
            int number = ctx.Families.Count(family => family.Adults.Any(adult => adult.HairColor.Equals("Black")) &&
                                                      family.Children.Any(child => child.HairColor.Equals("Black")));

            Assert.AreEqual(355, number);
        }


        // answer: 47
        [Test]
        public virtual void How_Many_Families_Have_A_Child_With_Black_Hair_Playing_Ultimate()
        {
            // count number of families where at least one child has black hair and plays ultimate
            int number = ctx.Families.Count(family => family.Children.Any(child => child.Interests.Any(
                interest => interest.Type.Equals("Ultimate") && child.HairColor.Equals("Black"))));
            Assert.AreEqual(47,number);
        }


        // answer: 172
        [Test]
        public virtual void HowManyFamiliesHaveTwoAdultsWithSameHairColor()
        {
        }

        // answer: 90
        [Test]
        public virtual void HowManyFamiliesHaveAChildWithAHamster()
        {
            int number = ctx.Families.Count(family =>
                family.Children.Any(child => child.Pets.Any(pet => pet.Species.Equals("Hamster"))));
            Assert.AreEqual(90, number);
        }

        
        // Answer: 5
        [Test]
        public virtual void HowManyChildrenAreInterestedInBothSoccerAndBarbies()
        {
            /*
            int number = ctx.Families.Any(f => f.Children.Any(c =>
                c.Interests.Any(i => i.Type.Equals("Barbies")) && c.Interests.Any(i => i.Type.Equals("Soccer"))));
                */
        }

        
        // answer 157
        [Test]
        public virtual void HowManyChildrenAreOfHeightBetween95And112()
        {
            int ChildrenHeight = ctx.Families.Sum(family =>
                family.Children.Count(child => child.Height > 94 && child.Height < 113));
            /*
            int ChildrenHeight = ctx.Families.Count(family =>
                family.Children.Any(child => child.Height > 94 && child.Height < 113));
                */
            Assert.AreEqual(157,ChildrenHeight);
        }
    }
}