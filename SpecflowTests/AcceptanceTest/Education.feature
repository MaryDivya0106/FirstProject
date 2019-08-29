Feature: Education
	In order to update my profile 
	As a skill trader
	I want to add the Education that I know

	# Education Scenarios
	#//positive flow
	Scenario: Check if user could able to Add Education to Education Tab undr profile page.
	Given I click on  Education tab under Profile page.
	When  I enter all the fields and click on Add button.
	Then that Education list should Add into my Education listing.

	Scenario Outline: Check if user could able to add maximum education details. 
	Given I clicked on the education tab under Profile page
	When When I add all required details '<College_name>', '<Country>', '<Tittle>', '<Degree>','<Year>'
	Then that should be displayed on my education  listings
 
 Examples: 
         
	| College_name | Country      |   Tittle | Degree    | Year     |
		 | CJITS   |   India      |  B.Tech  | Bachelors |   2016   |
		 | SR      |   India      |  M.Tech  |  Masters  |   2018  |
		 | JNTU    |   India      |  PHD     |   Higher   |       2019 |


	 Scenario: Check if user didn't give all inputs and try to click on Add.
	Given I click on the Education tab under Profile page and clicked on add New Button.
	When  I enter all the fields except University and click on Add button.
	Then I should able to see  Tool Tip as Please enter all the fields.

	 Scenario: Check if give all inputs and try to click on Cancel button.
	Given I click on the Education tab,  Add New Button under Profile page.
	When  I enter all the fields and click on Cancel button.
	Then That language should not add to the list.
	
	Scenario: Check if user is able to select from dropdown.
	Given I click on the Education tab,Add New Button under Profile page.
	When  I clicked on  dropdown and able to select Country from dropdown.
	Then Thet country should be displayed in the box .

	Scenario: Update Existing ducation
	Given I click on the Education tab under Profile page and clicked on Update icon
	When  I updated the current Tiitle name to new Title and i clicked on Update button.
	Then I should able to see the tooltip as Education Updated.

	Scenario: Check if user gives Existing data.
	Given I click on the Education tab under Profile page and clicked on Add New button.
	When  I gave same inputs which exists and clicked on Add button.
	Then I shoul able to see Tool Tip as Information already exist .

	Scenario: Check if user gives Null values after clicking update.
	Given I click on the Education tab under Profile page and clicked on update button.
	When  I gave null values and clicked on update button.
	Then I should able to see Tool Tip as enter all fields .

	Scenario: Check if user is able to click on delete button.
	Given I click on the Education tab under Profile page.
	When  I clicked on particulat education delete icon.
	Then that education details should delete from the list.

	Scenario: Check if user is able to give all fields and click on Add button.
	Given I click on the Education tab under Profile page and clicked on Add new button.
	When  I gave all same data and changed single field and clicked on Add button.
	Then that education details should Add to the list.
	