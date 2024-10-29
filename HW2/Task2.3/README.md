Task 2.3

Suppose that Coherent solutions develops a training management system. Each training consists of a set of lectures and practical exercises.
It is necessary to create classes to represent the following entities: training, lecture, practical lesson.

All specified entities have a text description (this is an arbitrary string, possibly empty or equal to null).

The lecture has a topic (an arbitrary string, possibly empty or equal to null), and a practical lesson has a link to the task condition 
(an arbitrary string, possibly empty or equal to null) and a link to the solution (an arbitrary string, possibly empty or equal to null).

The training must store a set of lectures and practical exercises in an internal array and have an Add() method for adding a lecture or practical exercise. 
In addition, the training must have a method IsPractical() - returns true if the training contains only practical exercises.

Implement an instance method Clone() in the training class to clone the training. Note: Deep cloning must be performed, not shallow cloning.