package main

// Lab 3 Question
import (
	"fmt"
)

func main() {

	// Part 1
	faaiz := 2
	address := &faaiz
	fmt.Println("Adress of the variable named Faaiz: ", address)
	fmt.Println("Pointer fetching the value using. the address: ", *address)
	fmt.Println()

	// Part 2
	fmt.Println("Value before modification:", faaiz)

	modifyVariable(&faaiz)

	fmt.Println("Value after modification:", faaiz)
	fmt.Println()

	// Part 3
	s1 := new(Student)
	fmt.Println("Structure Data before Modification: ")
	fmt.Println(*s1)
	fmt.Println()

	modifyStructureVariable(s1) //as s1 is already a pointer
}

type Student struct {
		Name string
		Age int
		Marks float32
	}

func modifyStructureVariable(s1 *Student) {
	s1.Name = "faaiz"
	s1.Age = 23
	s1.Marks = 100
	fmt.Println("Structure Data after Modification: ")
	fmt.Println(*s1)
}

func modifyVariable(p *int) {
	*p = 10; //PassByReference
}
