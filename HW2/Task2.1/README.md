Task 2.1

Suppose that an IT company is developing a project called "Planetarium on the computer." 
It is necessary to create and test a class for a point with mass in three-dimensional space. 
Point coordinates X,Y,Z are arbitrary integers, and mass (Mass) is a real number greater than or equal to 0.

Requirements:
	1. Create a class to represent a point in three-dimensional space that has mass. 
	To store the coordinates of a point, use an array of three elements (private field).
	2. Provide the class with separate public properties for reading and setting each coordinate and mass (properties named X, Y, Z, and Mass).
	3. If someone tries to set the mass to a negative value, set the mass to 0.
	4. Provide the class with the IsZero() method, which returns true if all coordinates of the point are 0.
	5. Provide the class with a method that receives another point object as a parameter. 
	The method must return the distance between the current point and the parameter point. To extract the square root, use the Math.Sqrt() method.
	6. Test the created class, the operation of its properties, and methods in a console application.