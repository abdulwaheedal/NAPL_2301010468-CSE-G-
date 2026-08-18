package main

import "fmt"

func main() {
	var operation int
	var int1 int
	var int2 int
	var float1 float64
	var float2 float64

	for {
		fmt.Println("\nSelect serial number to perform your desired operation\n1. Perform Operations using Int\n2. Perform operations using Float\n3. exit")
		fmt.Scanln(&operation)

		if (operation == 1)	{
			fmt.Println("Integer Operations\n")

			fmt.Println("Input first integer")
			fmt.Scanln(&int1)
			fmt.Println("Input second integer")
			fmt.Scanln(&int2)

			fmt.Println("Integer Operations")
			fmt.Printf("Subtraction = %d\n", int1 - int2)
			fmt.Printf("Addition = %d\n", int1 + int2)
			fmt.Printf("Division = %d\n", int1 / int2)
			fmt.Printf("Multiplication = %d\n", int1 * int2)
		} else if (operation == 2){
			fmt.Println("Float Operations\n")
			
			fmt.Println("Input first Float number")
			fmt.Scanln(&float1)
			fmt.Println("Input second Float number")
			fmt.Scanln(&float2)

			fmt.Printf("Subtraction = %f\n", float1 - float2)
			fmt.Printf("Addition = %f\n", float1 + float2)
			fmt.Printf("Division = %f\n", float1 / float2)
			fmt.Printf("Multiplication = %v\n", float1 * float2)
		} else if (operation == 3) {
			break
		} else {
			fmt.Println("Invalid Input")
		}
	}
}
