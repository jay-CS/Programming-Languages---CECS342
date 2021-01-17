#include <iostream>
#include <string>
#include <list>
#include <algorithm>
#include <array>
#include <vector>

using namespace std;

//Generic person class. 
template <class type1, class type2>
class Person {

public:
	type1 name;
	type2 age;

public:
	Person(type1 n, type2 a) {
		name = n;
		age = a;
	}
	bool operator<(Person<type1, type2> & personObj);
};

//Overloaded "<" operator to be used in sorting.
//Sorts by age.
template <class type1, class type2>
bool Person<type1, type2>::operator < (Person<type1, type2> & personObj) {
	if (age == personObj.age) {
		return name < personObj.name;
	}
	return age > personObj.age;
}
//Binary function to determine which argument is greatest.
template <typename type1, typename type2>
bool byName (Person<type1, type2> & person1, Person<type1, type2> & person2) {
	if (person1.name == person2.name)
		return person1 < person2;// The "<" operator was overloaded in the Person class.
	return person1.name < person2.name;
}


//Generic function to print out an array.
template<class T>
void printArray(T a[], int size) {
	for (int i = 0; i < size; i++) {
		cout << a[i] << " ";
	}
	cout << endl;


}
//Function to print out a vector of "Person".
void printvec(vector <Person<string, int>> const &a) {
	for (int i = 0; i < a.size(); i++) {
		cout << a.at(i).name << ", " << a.at(i).age << endl;
	}
}

int main() {

	float myArr[] = { 645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26 };
	int myArrSize = sizeof(myArr) / sizeof(myArr[0]);
	cout << "Initial Array: ";
	printArray(myArr, myArrSize);
	//initial(myArr) and final positions(myArr+size) of the sequence to be sorted.
	sort(myArr, myArr + myArrSize);
	cout << "Sorted Array: ";
	printArray(myArr, myArrSize);

	vector<Person<string, int>> myPPL{
	Person<string, int>("Hal", 20),
	Person<string, int>("Susann", 31),
	Person<string, int>("Dwight", 19),
	Person<string, int>("Kassandra", 21),
	Person<string, int>("Lawrence", 25),
	Person<string, int>("Cindy", 22),
	Person<string, int>("Cory", 27),
	Person<string, int>("Mac", 19),
	Person<string, int>("Romana", 27),
	Person<string, int>("Doretha", 32),
	Person<string, int>("Danna", 20),
	Person<string, int>("Zara", 23),
	Person<string, int>("Rosalyn", 26),
	Person<string, int>("Risa", 24),
	Person<string, int>("Benny", 28),
	Person<string, int>("Juan", 33),
	Person<string, int>("Natalie", 25)
	};

	cout << "\nInitial List: " << endl;
	printvec(myPPL);

	cout << "\nSorting List by Age: " << endl;
	//initial(begining of myPPL vector) and final positions(end of myPPL vector) of the sequence to be sorted.
	sort(myPPL.begin(), myPPL.end());
	printvec(myPPL);

	cout << "\nSorting List by Name: " << endl;
	//Use the function byName as the method for comparing values.
	sort(myPPL.begin(), myPPL.end(), byName<string,int>);
	printvec(myPPL);

	int x;
	cin >> x;
}
