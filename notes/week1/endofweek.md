# Plan

(I'm muted - just give me minute.)

1. Show some miscellaneous syntax stuff.
    - More OOP
        - Properties
        - Methods and Method Overloading
        - Records
    - Delegates (`() =>` functions.)
2. Look briefly at the LinksApi and show some of the stuff we've covered.
3. At about ~3:00 - send you on your own. Or hang out with me and ask stuff or chat.


-- TLDR

- Knowing your tools - navigating
- thinking in code (specifically, this week, C#)
    - public class BankAccount(ICalculateBonuses bonusCalculator) {}
    - ... inject(BonusCalculator);
    - Not so much HOW to do this, but WHY do we do this?
    - Reduces Coupling
        - Changes in X can break Y.
        - Work has to broken up across members of a team.
        - We do not use things like databases, networks and stuff like that in UNIT tests. 
    - How do you write code when you don't know how to write code yet?
        - Writing tests first (TDD) is a good way to do it.
            - Take tiny bites, and eventually you'll eat the elephant.
            - Newer developers have a tendency to do two things:
                -  over engineer their solutions - trying to impress?
                -  getting stuck and not asking for help until too late.

