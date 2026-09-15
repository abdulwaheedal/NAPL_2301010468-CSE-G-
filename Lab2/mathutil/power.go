package mathutil

func Power(a int, b int) int {
	var x int = 1
	for i := 0; i < b; i ++ {
		x *= a
	}

	return x
}
