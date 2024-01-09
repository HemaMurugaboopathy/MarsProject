Feature: SkillsPage

As a user I want to login to Mars portal and create, edit and delete a skill
so that I can manage my skills list

@tag1
Scenario Outline: 01- Delete all records before adding any skill
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I delete all records in the skills page
	
Scenario Outline: 02 -  Add a new skill with a valid detail
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I create a new '<skills>' and '<skill Level>' 
	Then the '<message>' should be shown on the skill page
	
	Examples: 
	| skills | skill Level | message							|
	| C#     | Expert      | C# has been added to your skills	|

Scenario Outline: 03 - Edit an existing skill with a valid detail
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I edit an existing '<existing Skill>' and '<existing Skill Level>'
	Then the '<new Skill>' and '<new Skill Level>' should be updated successfully for skills page

Examples: 
| existing Skill | existing Skill Level | new Skill | new Skill Level | message               |
| C#             | Expert               | Java      | Beginner        | Java has been updated to your skills |

Scenario Outline: 04 - Delete the existing skill
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I delete an existing '<existing Skill>' in skill page
	Then the '<message>' should be shown on the skill page
	
Examples: 
| existing Skill | message |
| Java  | Java has been deleted |

Scenario Outline: 05 - Leave the skills textbox empty
	Given I logged in Mars portal successfully
	When I navigate to skill page
	Then I create a new '<skills>' and '<skill Level>' 
	Then the '<message>' should be shown on the skill page

	Examples: 
	| skills | skill Level | message                             |
	|        | Expert      | Please enter skill and experience level |

