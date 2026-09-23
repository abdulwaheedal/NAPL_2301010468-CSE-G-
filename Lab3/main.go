package main

// Lab 3
import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	var p1 Person
	var p2 Person

	p1.readData()
	fmt.Println()
	p2.readData()

	fmt.Println()
	
	p1.writeData()
	fmt.Println()
	p2.writeData()
} 

type Person struct {
	Name string
	Age int
	Job string
	Salary float64
}


func (p1 *Person) readData() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Enter Name: ")
	fmt.Scan(&p1.Name)
	reader.ReadLine()

	fmt.Println("Enter Age: ")
	fmt.Scanln(&p1.Age)

	fmt.Println("Enter Job: ")
	fmt.Scan(&p1.Job)
	reader.ReadLine()

	fmt.Println("Enter Salary: ")
	fmt.Scanln(&p1.Salary)
}

func (p1 Person) writeData() {
	fmt.Printf("Name   : %s\n", p1.Name)
	fmt.Printf("Age    : %d\n", p1.Age)
	fmt.Printf("Job    : %s\n", p1.Job)
	fmt.Printf("Salary : ₹%.2f\n", p1.Salary)
}
