
public static class Priority
{
    public static void Test()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        bool allTestsPassed = true;
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Enqueue items with different priorities, then dequeue them.
        // Expected Result: Items should be dequeued in order of highest priority first.
        Console.WriteLine("Test 1");
        try
        {
            priorityQueue.Enqueue("A", 1);
            priorityQueue.Enqueue("B", 3);
            priorityQueue.Enqueue("C", 2);

            if (priorityQueue.Dequeue() != "B" ||
                priorityQueue.Dequeue() != "C" ||
                priorityQueue.Dequeue() != "A")
            {
                Console.WriteLine("Test 1 Failed");
                allTestsPassed = false;
            }
            else
            {
                Console.WriteLine("Test 1 Passed");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed: Unexpected exception - {e.Message}");
            allTestsPassed = false;
        }
        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Attempt to dequeue from an empty queue.
        // Expected Result: An ApplicationException should be thrown.
        Console.WriteLine("Test 2");
        try
        {
            priorityQueue.Dequeue();
            Console.WriteLine("Failed: Expected ApplicationException but none was thrown");
            allTestsPassed = false;
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Test 2 Passed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed: Unexpected exception - {e.Message}");
            allTestsPassed = false;
        }

        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below

        // Test 3: Equal Priority
        // Scenario: Enqueue items with the same priority, then dequeue them.
        // Expected Result: Items should be dequeued in the order they were enqueued (FIFO).
        Console.WriteLine("Test 3");
        try
        {

            priorityQueue.Enqueue("D", 5);
            priorityQueue.Enqueue("E", 5);

            if (priorityQueue.Dequeue() != "D" ||
                priorityQueue.Dequeue() != "E")
            {
                Console.WriteLine("Test 3 Failed");
                allTestsPassed = false;

            }
            else
            {
                Console.WriteLine("Test 3 Passed");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed: Unexpected exception - {e.Message}");
            allTestsPassed = false;
        }

        // Test 4: Large Queue  
        // Scenario: Enqueue a large number of items with varying priorities.
        // Expected Result: Items should be dequeued in the correct priority order.
        try
        {
            Random random = new Random();
            int numItems = 1000; // Number of items to enqueue

           
            for (int i = 0; i < numItems; i++)
            {
                string value = $"Item{i + 1}";
                int priority = random.Next(1, 11);
                priorityQueue.Enqueue(value, priority);
            }

            int highestPriority = 10;

            // Dequeue and check priority order
            for (int i = 0; i < numItems; i++)
            {
                string dequeuedItem = priorityQueue.Dequeue();
                int dequeuedPriority = int.Parse(dequeuedItem.Split(' ')[1].Substring(4, dequeuedItem.Split(' ')[1].Length - 5)); // Extract priority from string

                if (dequeuedPriority > highestPriority)
                {
                    Console.WriteLine($"Test 4 Failed: Priority order violated. Expected priority <= {highestPriority}, got {dequeuedPriority}");
                    allTestsPassed = false;
                    break;
                }

                highestPriority = dequeuedPriority;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test 4 Failed: Unexpected exception - {e.Message}");
            allTestsPassed = false;
        }

        // Overall Test Results
        if (allTestsPassed)
        {
            Console.WriteLine("All Tests Passed!");
        }
        else
        {
            Console.WriteLine("One or more tests failed.");
        }
    }
}