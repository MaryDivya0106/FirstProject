#Feature: SpecFlowFeature1
#	In order to update my profile 
#	As a skill trader
#	I want to add the Skill that I know
#
#	#
#	#//Certification
#
#Scenario: Check if user could able to add Certificates under profile page.
#	Given I click on the Certification tab under Profile page.
#	When  I enter all the fields and click on Add button.
#	Then that Certificate list should Add into my Certification listing.
#
#
#	
#	Scenario Outline: Check if user could able to add maximum education details. 
#	Given I clicked on the education tab under Profile page
#	When When I add all the required details '<College_name>', <Country>','<Tittle>', <Degree>','<Year>'
#	Then that should be displayed on my education  listings
# 
# Examples: 
#         
#		 |Certificate | From      |   Year| 
#		 |  Java  |   India      |  2018  | 
#		 |  C#     |   India      |  2019  | 
#		 
#
#	
#	 Scenario: Check if user didn't give all inputs and try to click on Add.
#	Given I click on the Certification tab under Profile page and clicked on add New Button.
#	When  I enter all the fields except certificate from and click on Add button.
#	Then I should able to see  Tool Tip as enter all Certificate name,from,year .
#
#	 Scenario: Check if user give all inputs and try to click on Cancel button.
#	Given I click on the certification tab Add New Button under Profile page.
#	When  I enter all the fields and click on Cancel button.
#	Then That certificate should not add to the list.
#
#	Scenario: Check if user is able to select from dropdown.
#	Given I click on the certification tab,Add New Button under Profile page.
#	When  I clicked on  dropdown and able to select year from dropdown.
#	Then Thet year should be displayed in the box .
#
#	Scenario: Check if user is able to click on edit icon to update.
#	Given I click on the certification tab under Profile page and clicked on Update icon.
#	When  I updated the current certificate name to  in certification Tab and i clicked on Add button.
#	Then That current certificate should be displayed in the box .
#
#	Scenario: Check if user gives Existing data.
#	Given I click on the certification tab under Profile page and clicked on Add New button.
#	When  I gave same inputs which exists and clicked on Add button.
#	Then I shoul able to see Tool Tip as Information already exist .
#
#	Scenario: Check if user gives Null values after clicking update.
#	Given I click on the certification tab under Profile page and clicked on update button.
#	When  I gave null values and clicked on update button.
#	Then I should able to see Tool Tip as enter all fields .
#
#	
#	Scenario: Check if user is able to click on delete button.
#	Given I click on the certification tab under Profile page.
#	When  I clicked on particular certificate delete icon.
#	Then that certificate  details should delete from the list.
#
#	Scenario: Check if user is able to give all fields and click on Add button.
#	Given I click on the certificate tab under Profile page and clicked on Add new button.
#	When  I gave all same data and changed single field and clicked on Add button.
#	Then that certificate details should Add to the list.
