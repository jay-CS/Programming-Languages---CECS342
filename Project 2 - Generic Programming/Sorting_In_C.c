#include <stdio.h>
#include <stdlib.h>
#include <string.h>



//Struct that creates the people data type
typedef struct People {
    char *name;
    int age;
} People;

//A distinct value represented for the data types
enum dataTypes {
    INT, FLOAT, STRING, PEOPLE, AGE
} type;

//Compare functions for qsort to allow for generic compares of data tyes INT, FLOAT, STRING, PEOPLE, and AGE
int compareFunction (const void *a, const void *b) {
  switch(type) {
    case INT:
      return (*(int*)a - *(int*)b);
    case FLOAT:
      return (*(float*)a - *(float*)b);
    case STRING:
      return strcmp(*(char**)a, *(char**)b);
    case PEOPLE:
      return strcmp(((People*)a)->name, ((People*)b)->name);
    case AGE:
      if (((People*)a)->age == ((People*)b)->age) {
        return strcmp(((People*)a)->name, ((People*)b)->name);
      }else{
        return ((People*)b)->age - ((People*)a)->age;
    }
  }
}

//print function that has a void pointer set to the list bring printed and uses the enumerated type declared before the function call to select which type case is correct
void print(void *list, int size){
  printf("\033[0;32m");
  for(int x = 0; x < size; x++){
    switch(type) {
      case INT:
        printf(" %d\n", ((int*)list)[x]);
        break;
      case FLOAT:
        printf(" %.2f\n", ((float*)list)[x]);
        break;
      case STRING:
        printf(" %s\n", ((char**)list)[x]);
        break;
      case PEOPLE:
      case AGE:
        printf(" %s,%d\n", ((People*)list)[x].name, ((People*)list)[x].age);
        break;
      }
  }
  printf("\033[0m");
  printf("\n");
}


int main(void) {
//------------Main for Bryan's C Code---------------

  //Enumerated type set to FLOAT
  type = FLOAT;
  float numbers[] = { 645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26 };
  int sizeFloat = (sizeof(numbers)/sizeof(numbers[0]));
  printf("\033[0;34m");
  printf("Unsorted Float Numbers: \n");
  printf("\033[0m");
  print(numbers, sizeFloat);
  qsort(numbers, sizeFloat, sizeof(float), compareFunction);
  printf("\033[0;34m");
  printf("Sorted Float Numbers: \n");
  printf("\033[0m");
  print(numbers, sizeFloat);

  //Enumerated type set to PEOPLE
  type = PEOPLE;
  People person[] = { 
    {"Hal", 20}, 
    {"Susann", 31},
    {"Dwight", 19},
    {"Kassandra", 21}, 
		{"Lawrence", 25},
    {"Cindy", 22}, 
    {"Cory", 27}, 
    {"Mac", 19},
    {"Romana", 27}, 
    {"Doretha", 32},
    {"Danna", 20}, 
    {"Zara", 23}, 
    {"Rosalyn", 26}, 
    {"Risa", 24}, 
    {"Benny", 28},
    {"Juan", 33}, 
    {"Natalie", 25}
  }; 

 
  int sizePerson = (sizeof(person)/sizeof(person[0]));
  printf("\033[0;34m");
  printf("Unsorted People: \n");
  printf("\033[0m");
  print(person, sizePerson);
  qsort(person, sizePerson, sizeof(People), compareFunction);
  printf("\033[0;34m");
  printf("Sorted People Alphabetically: \n");
  printf("\033[0m");
  print(person, sizePerson);

  //Enumerated type set to AGE
  type = AGE;
  qsort(person, sizePerson, sizeof(People), compareFunction);
  printf("\033[0;34m");
  printf("Sorted People Age then Alphabetically: \n");
  printf("\033[0m");
  print(person, sizePerson);

  return 0;
}