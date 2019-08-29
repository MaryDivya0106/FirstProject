Feature: Description
	In order to update my profile 
	As a skill trader
	I want to add the Education that I know

@Desc1
Scenario: Scenario:Check if user is able to Enter text by starting with specialcharacters
Given I clicked on Edit button of Description in profile pageing page
When I enterd text starting with special charcters in Description field 
And I clicked on Save button
Then I should able to see error message.

@Desc2
Scenario: Scenario:Check if user is able to Enter text by starting with space
Given I clicked on Edit button of Description in profile pageing page
When I enterd text starting with space in Description field 
And I clicked on Save button
Then I should able to see error message.

@Desc3
Scenario: Scenario:Check if user is able to save by giving null values
Given I clicked on Edit button of Description in profile pageing page
When I leave the descrption field as empty 
And I clicked on Save button
Then I should able to see error message.

@Desc4
Scenario: Scenario:Check if user is able to save with lower and upper case letters
Given I clicked on Edit button of Description in profile pageing page
When I have given text in lower and upper case letters
And I clicked on Save button
Then I should able to see message saved.

@Desc5
Scenario: Scenario:Check if user is able to see characters remaining ubder textbox
Given I clicked on Edit button of Description in profile pageing page
When I have given text in Description field
Then I should able to see characters remaining to allow.

