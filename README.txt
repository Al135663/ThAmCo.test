Project Structure
	1. ThAnCo.Events:Manages events and interactions with guests and staff.
	2. ThAmCo.Catering: Defines food items, menus, and catering bookings.
	3.ThAmCo.Venues: Handles venue availability and reservations.
Each project is organized into Controllers, Data, and Models folders, with a focus on separation of concerns and modularity.



Key Design Decisions:
    1. Method Overloading vs. New Method in Catering Service



 ---------------------------------------------------------------------
    2. Asynchronous vs. Synchronous Code for Database Operations. 

       Challenge: To load data for events and guests efficiently.

           1. Asynchronous (Task-based): Improves performance and responsiveness, especially beneficial under high load.
           2. Synchronous: Easier to implement but can lead to blocking, especially for I/O-bound operations.

     Decision: Chose asynchronous methods for scalability and performance.
*** Reference: Microsoft docs on async programming.

--------------------------------------------------------------------
  3.  Entity Relationships with Fluent API vs. Data Annotations.

     Challenge: Define complex relationships like many-to-many between Menu and FoodItem in CateringDbContext

   Decision: Fluent API was selected for defining relationships to allow for composite keys and custom delete behaviors.

