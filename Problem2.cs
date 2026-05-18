// Time Complexity : O(m+n)
// Space Complexity : O(m+n)
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

/*

*/

public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int count = 0;
        Dictionary<int, List<int>> adjMap = new();
        int[] inwardCount = new int[numCourses];

        foreach(int[] prereq in prerequisites)
        {
            inwardCount[prereq[1]] += 1;

            if(!adjMap.ContainsKey(prereq[0]))
            {
                adjMap[prereq[0]] = new List<int>();
            }

            adjMap[prereq[0]].Add(prereq[1]);
        }

        Queue<int> q = new();

        for(int i = 0; i < inwardCount.Length; i++)
        {
            if(inwardCount[i] == 0)
            {
                q.Enqueue(i);
                count += 1;
            }
        }

        if(q.Count == 0)
        {
            return false;
        }

        while(q.Count != 0)
        {
            int currentCourse = q.Dequeue();

            if(adjMap.ContainsKey(currentCourse))
            {
                List<int> nextCourses = adjMap[currentCourse];
                
                foreach(int course in nextCourses)
                {
                    inwardCount[course] -= 1;
                    if(inwardCount[course] == 0)
                    {
                        q.Enqueue(course);
                        count += 1;
                    }
                }
            }

        }

        return count == numCourses;
    }
}