from collections import namedtuple

def main():
  numbers = [645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26]

  sorted_numbers = sorted(numbers)
  print("\nSorted Numbers by numerical value")
  print(sorted_numbers)
  
  Person = namedtuple('Person', ['name', 'age'])
  people = [
    Person("Hal", 20), 
    Person("Susann", 31),
    Person("Dwight", 19),
    Person("Kassandra", 21), 
		Person("Lawrence", 25),
    Person("Cindy", 22), 
    Person("Cory", 27), 
    Person("Mac", 19),
    Person("Romana", 27), 
    Person("Doretha", 32),
    Person("Danna", 20), 
    Person("Zara", 23), 
    Person("Rosalyn", 26), 
    Person("Risa", 24), 
    Person("Benny", 28),
    Person("Juan", 33), 
    Person ("Natalie", 25)
  ]

  # key specifies a function of one argument that is used to extract a comparison key from each element in iterable.
  print("\nSorted people alphabetically (lexicographically) by name")
  sorted_people = sorted(people, key= lambda Person: Person.name)
  for person in sorted_people:
    print(f"({person.name},{person.age})")

  print("\nSort people by age(descending) & lexicographical by name for same age")
  sorted_people = sorted(people, key= lambda Person: (-Person.age, Person.name))
  for person in sorted_people:
    print(f"({person.age},{person.name})")
  
if __name__ == '__main__':
  main()