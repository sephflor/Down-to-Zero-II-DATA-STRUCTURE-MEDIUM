using System;
using System.Collections.Generic;

public class Solution {
    
    public static int downToZero(int n) {
        if (n == 0) return 0;
        
        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> dist = new Dictionary<int, int>();
        
        queue.Enqueue(n);
        dist[n] = 0;
        
        while (queue.Count > 0) {
            int current = queue.Dequeue();
            
            if (current == 0) {
                return dist[current];
            }
            
            // Option 1: Subtract 1
            int next = current - 1;
            if (!dist.ContainsKey(next)) {
                dist[next] = dist[current] + 1;
                queue.Enqueue(next);
            }
            
            // Option 2: For each factor, move to max(a, b)
            for (int i = 2; i * i <= current; i++) {
                if (current % i == 0) {
                    int factor = current / i;
                    next = Math.Max(i, factor);
                    if (!dist.ContainsKey(next)) {
                        dist[next] = dist[current] + 1;
                        queue.Enqueue(next);
                    }
                }
            }
        }
        
        return -1;
    }

    public static void Main(string[] args) {
        int q = Convert.ToInt32(Console.ReadLine().Trim());
        
        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            int result = downToZero(n);
            Console.WriteLine(result);
        }
    }
}
