﻿Feature: SkillsPage

As a user I want to login to Mars portal and create, edit and delete a skill
so that I can manage my skills list

@tag1
Scenario: Add a new skill with a valid detail
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I create a new '<skills>' and '<skill Level>' 
	Then the '<skills>' and '<skill Level>' created successfully
	
	Examples: 
	| skills | skill Level |
	| C#     | Expert      |

Scenario Outline: Edit an existing skill with a valid detail
Given I logged in Mars portal successfully
When I navigate to skill page
Then I edit an existing '<existing Skills>' and '<existing Skill Level>'
Then the '<new Skills>' and '<new Skill Level>' should be updated successfully for skills page

Examples: 
| existing Skill | existing Skill Level | new Skill | new Skill Level |
| C#             | Expert               | Java      | Beginner        |