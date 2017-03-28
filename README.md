# WeightedGraphKata
A kata to explore building up a baysian graph from examples

The tasks are as follows:
First Task:
1. Given the input "a(0.8)b,a(0.2)c"
2. Assert that given an input of 0.9 node a returns node c
3. Assert that given an input of 0.1 node a returns node b


Second Task:
1. Given an input of "a()b,a()c,b()d,b()e"
2. Assert that a connects to e
3. Assert that given the route "a,b,d" the weight of a->c is 0 and a->b is 1
3. Assert that given the route "a,c" the weight of
  - a->c is 0.5
  - a->b is 0.5
  - b->d is 1
  - b->e is 0

Third Task:
1. Replay the commands above on another set of objects
2. For each returned node get a node given an input, show using the inputs 0.2 followed by 0 will result in node d
