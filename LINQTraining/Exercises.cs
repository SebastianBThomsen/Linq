using System;
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
        }


        // answer: 5
        [Test]
        public virtual void HowManyFamiliesLiveAt()
        {
            // street "Abby Park Street"
        }


        // answer 151
        [Test]
        public virtual void HowManyFamiliesHaveOneParent()
        {
            // we are looking for the number families, which have exactly one parent.

        }

        // answer: 123
        [Test]
        public virtual void HowManyFamiliesLiveInNumberThreeOrFive()
        {
            // no matter which street, just focus on house number
       
        }


        // answer: 94
        [Test]
        public virtual void HowManyFamiliesHaveADog()
        {
            // one or more dogs
            
        }

        // answer: 18
        [Test]
        public virtual void HowManyFamiliesHaveCatAndDog()
        {
            // one or more of either. But at least one dog, and at least one cat
          
        }


        // answer 125
        [Test]
        public virtual void HowManyFamiliesHave3Children()
        {
            // exactly 3 children
            
        }

        // answer: 175
        [Test]
        public virtual void How_Many_Families_Have_Gay_Parents()
        {
            // looking for families with two parents of the same sex
            // this one is pretty tough in one query, if you don't all ToList() before the end.
            
        }


        // answer 21
        [Test]
        public virtual void How_Many_Families_Have_An_Adult_With_Red_Hair()
        {
            // count the number of families with at least one adult with red hair.
        
        }


        // answer: 26
        [Test]
        public virtual void How_Many_Families_Have_2_Pets()
        {
            // Exactly 2 pets. Doesn't matter what type of pet. Ignore the children's pets for this one.
            
        }


        // answer: 81
        [Test]
        public virtual void How_Many_Families_Have_A_Child_Playing_Soccer()
        {
            // at least one child.
            
        }

        // answer: 355
        [Test]
        public virtual void How_Many_Families_Have_Adult_And_Child_With_Black_Hair()
        {
            // count number of families where at least one adult and one child have black hair
          
        }


        // answer: 47
        [Test]
        public virtual void How_Many_Families_Have_A_Child_With_Black_Hair_Playing_Ultimate()
        {
            // count number of families where at least one child has black hair and plays ultimate
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

        }

        
        // Answer: 5
        [Test]
        public virtual void HowManyChildrenAreInterestedInBothSoccerAndBarbies()
        {
        }

        
        // answer 157
        [Test]
        public virtual void HowManyChildrenAreOfHeightBetween95And112()
        {
        }
    }
}