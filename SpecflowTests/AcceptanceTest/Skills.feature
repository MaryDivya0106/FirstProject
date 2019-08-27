Feature: SkillFeature
	In order to update my profile 
	As a skill trader
	I want to add the Skill that I know

@tag1
 Scenario: Check if user could able to Add Skills by clicking Add New button under Skills tab.
	Given I clicked on the Skills tab under Profile page and clicked on Add New Button
	When I Entered Skill in TextBox and choosed level from skill dropdown and clicked on Add button
	Then that skill should add in to skill list.
	
	@tag2
	Scenario Outline: Check if user could able to add  multiple Skills 
	Given I clicked on the skills tab under Profile page
	When When I add a new "<Skill>"
	Then that "<Skill>" should be displayed on my listings
 
 Examples: 
         
		 | Skill |
		 | Reading |
		 | Coding  |

@tag3
	 Scenario: Update added skill 
	Given I clicked on the skills tab under Profile page.
And   I clicked on the Skill Edit Symbol.
	When i changed the Skill in Skill tab and selected level from dropdown list.
	And  i clicked on the Skill Update Button.
	Then that updated Skill should be displayed in my Skill tab with new Skill.
	

	 Scenario:Check if user try's to Update with null fields
	 Given I clicked on Skill tab under Profile page.
	 When I leave skill tab and level empty and clicked on Update Button.
	 Then I should able to see popup to enter Skill and level.
	 

	
	 Scenario: Checking if user is able to click on cancel 
	Given when i clicked on the Skills tab under Profile page.
	And i updated skill tab by selecting edit symbol.
	When  i clicked on the Cancel Button.
	Then that skill should not updated with new skill.


	
	 Scenario: Check if user could able to Delete Skill.
	Given I click on the Skill tab under Profile page.
	When  I click on the delete symbol.
	Then that skill should Delete from my skills listing.

	 Scenario: Check if user gives duplicate Skill values.
	Given I click on skills tab under Profile page.
	When  I click on Add New button .
	And I entered existing skill and changed level and clicked on Add button.
	Then I should able to see tool tip intimating Duplicated data.

	Scenario: Check if user gives existing Skill data.
	Given I click on skill tab below Profile page.
	When  I clicked on the Add New button .
	And I entered existing skill and level and clicked on Add button.
	Then I should able to see tooltip intimating as Skill Exists.

	Scenario: Check if user gives null values.
	Given I click on skill tab below Profile page.
	When  I clicked on the Add New button .
	And I did not give inputs and click on Add button.
	Then I should able to see tooltip intimating as Enter lnguage and level.





	
	



