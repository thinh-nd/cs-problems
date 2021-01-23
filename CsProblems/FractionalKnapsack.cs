using System;
using System.Collections.Generic;
using System.Linq;

namespace CsProblems
{
    public class FractionalKnapsack
    {
        /// Since you can take any fraction of any piece, the greedy choice property is to take an item, or a fraction of an item with highest value-to-weight ratio
        /// Proof: 
        ///     Suppose you can fill the sack with an item, or a fraction of an item that does not have the highest value-to-weigh ratio, but yield higher total value
        ///     If you subtitute that item/fraction with a higher value-to-weight ratio, then the value of the sack will increase, contradicting the above statement
        ///     Therefore, the greedy choice property holds as you alway need to pick the item/fraction with the highest value-to-weight ratio
        public static float[] FillSack(int[] values, int[] weights, int maxWeight)
        {
            if (values.Length != weights.Length)
            {
                throw new ArgumentException("Mismatch number of values and weights");
            }

            // n = values.Length = weights.Length
            var valuePerWeights = new Dictionary<int, float>(weights.Length); // O(n)
            for (int i = 0; i < weights.Length; i++) // O(n)
            {
                valuePerWeights.Add(i, (float) values[i] / weights[i]);
            }

            // uses Array.Sort internally => O(n*logn) on average, O(n^2) worst according to .NET docs
            var orderedValuePerWeights = valuePerWeights.OrderByDescending(dic => dic.Value).ToArray(); 

            var quantities = new float[weights.Length];
            Array.Fill(quantities, 0); // O(n)
            var remainingWeight = maxWeight;
            for (int i = 0; i < orderedValuePerWeights.Length; i++) // O(n)
            {
                var weightIndex = orderedValuePerWeights[i].Key;
                var weight = weights[weightIndex];
                if (weight > remainingWeight)
                {
                    quantities[weightIndex] = (float)remainingWeight / weight;
                    remainingWeight = 0;
                    break;
                }
                else
                {
                    quantities[weightIndex] = 1;
                    remainingWeight -= weight;
                }
            }
            // Combine time complexity: O(n*logn)-O(n^2)
            return quantities;
        }
    }
}
