// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Console.WriteLine(FindGreatestSum(new int[]{3, -4, 4, -3, 5, -9}));
Console.WriteLine(FindGreatestSum(new int[]{-2, 1, 0, -7, 62, -100}));
Console.WriteLine(FindGreatestSumNegatives(new int[]{3, -4, 4, -3, 5, -9}));
Console.WriteLine(FindGreatestSumNegatives(new int[]{-2, 1, 0, -7, 62, -100}));

int FindGreatestSum(int[] array) {
	var currentSum = 0;
	var greatestSum = 0;

	foreach(var n in array) {
		if ((currentSum + n) < 0) {
			currentSum = 0;
		}
		else {
			currentSum += n;

			if (currentSum > greatestSum) {
				greatestSum = currentSum;
			}
		}
	}

	return greatestSum;
}

int FindGreatestSumNegatives(int[] array) {
    if (array.Length == 0) return 0; 

    int currentSum = array[0];
    int greatestSum = array[0];

    for (int i = 1; i < array.Length; i++) {
        currentSum = Math.Max(array[i], currentSum + array[i]);
        greatestSum = Math.Max(greatestSum, currentSum);
    }

    return greatestSum;
}