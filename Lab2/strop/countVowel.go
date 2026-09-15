package strop

func Count(str string) int {
	count := 0
	arr := [5]string{"a", "e", "i", "o", "u"}
	for i := 0; i < len(str); i++ {
		for j := 0; j < 5;j++ {
			if string(str[i]) == arr[j] {
				count++
			}
		}
	}
	return count
}
