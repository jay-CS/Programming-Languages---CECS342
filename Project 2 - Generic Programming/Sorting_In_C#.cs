using System;
using System.Linq;
using System.Collections.Generic;

class generics {
  
  struct Person {
    public string name;
    public int age;
  }

  /**
    Prints out elements in an array of any standard data type
  */
  static void printArr<T>(IList<T> arr) {
      foreach (T e in arr)
          Console.WriteLine(e);
  }

  /**
    Sorts people by age and prints them in ascending order
    Uses Linq OrderBy method to sort in ascending order
  */
  static void printPersonByName(Person[] arr) {
    IEnumerable<Person> query = arr.OrderBy(Person => Person.name);
    foreach (Person p in query) {
        Console.WriteLine("{0} - {1}", p.name, p.age);
    }
  }

  /**
    Sorts people by name and prints them in lexigraphically ascending order
    Uses Linq OrderByDescending method to sort in lexigraphcally descending order
  */
  static void printPersonByAge(Person[] arr) {
    IEnumerable<Person> query = arr.OrderByDescending(Person => Person.age).ThenBy(Person => Person.name);
    foreach (Person p in query) {
        Console.WriteLine("{0} - {1}", p.name, p.age);
    }
  }

  static void Main(string[] args) {

          Console.WriteLine("--------PERSON STRUCT SORTING--------");
          Person[] personArr = { new Person() { name = "Hal", age = 20 },
                          new Person() { name = "Susann", age = 31},
                          new Person() { name = "Dwight", age = 19},
                          new Person() { name = "Kassandra",age = 21},
                          new Person() { name = "Lawrence", age = 25},
                          new Person() { name = "Cindy", age = 22},
                          new Person() { name = "Cory", age = 27},
                          new Person() { name = "Mac", age = 19},
                          new Person() { name = "Romana", age = 27},
                          new Person() { name = "Doretha", age = 32},
                          new Person() { name = "Danna", age = 20},
                          new Person() { name = "Zara", age = 23},
                          new Person() { name = "Rosalyn", age = 26},
                          new Person() { name = "Risa", age = 24},
                          new Person() { name = "Benny", age = 28},
                          new Person() { name = "Juan", age = 33},
                          new Person() { name = "Natalie", age = 25} };

          // Sort by name
          Console.WriteLine("--------BY NAME--------");
          printPersonByName(personArr);

          // Sort by age
          Console.WriteLine("\n--------BY AGE--------");
          printPersonByAge(personArr);

          Console.WriteLine("\n-----FLOAT SORTING-----");
          float[] arr = { 645.32f, 37.40f, 76.30f, 5.40f, -34.23f, 1.11f, -34.94f, 23.37f, 635.46f, -876.22f, 467.73f, 62.26f };
          Array.Sort(arr);
          printArr(arr);
        
      }
    }