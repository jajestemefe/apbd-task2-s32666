APBD Task 2 - Equipment Rental System

How to run it

Just open the solution in your IDE and run `Program.cs`.



My Design Decisions

The instructions mentioned we shouldn't just put everything in one giant class like `Program.cs`, so here is how I split things up to make the responsibilities clear.

I created a specific `Rental` class. This class acts as a transaction that links a user to an item. I think this gives each class one clear responsibility: `Equipment` just worries about being equipment, and `Rental` handles the timeline. 



I kept `Program.cs` completely clean of any business logic. All the rules are handled inside `RentalService.cs`. This avoids tight coupling because the console doesn't need to know the exact rules; it just asks the service to process the rental, and the service handles the rest.



To store my data without setting up a real database, I used a `Singleton` mock database. It just holds simple lists of the users, equipment, and rentals. My tutor showed us this approach, and it makes it really easy for my `RentalService` to check active rentals without having to pass data lists all over the place.

