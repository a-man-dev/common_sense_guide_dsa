using Common;

/*
Exercise solutions:
19.1
For the array size of n elements, new collections array created with the size of n^2, so space complexity is O(n^2)

19.2
Its space complexity is O(n).
*/

// 19.3
string[] Reverse(string[] input) {
	for (var i = 0; i < input.Length /2; i++) {
		var temp = input[i];
		input[i] = input[input.Length - 1 - i];
		input[input.Length - 1 - i] = temp;
	}
	return input;
}

var words = new [] {"a", "b", "c", "d", "e"};
Reverse(words).PrintElements();

// 19.4
/*
Version   | Time Complexity   | Space Complexity (How much extra space allocated)
#1			 	O(n)		    	O(n)
#2				O(n)				O(1)
#3				O(n)                O(n) for call stack	
*/
