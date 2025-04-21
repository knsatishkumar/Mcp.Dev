Feature: Password Validation
    As a security-conscious application
    I want to ensure passwords meet strong requirements
    So that user accounts are better protected

Scenario: Password meets all requirements
    Given a password validator
    When I validate the password "SecurePass123!"
    Then the result should be valid

Scenario: Password is too short
    Given a password validator
    When I validate the password "Short1!"
    Then the result should be invalid

Scenario: Password missing uppercase
    Given a password validator
    When I validate the password "lowercase123!"
    Then the result should be invalid

Scenario: Password missing lowercase
    Given a password validator
    When I validate the password "UPPERCASE123!"
    Then the result should be invalid

Scenario: Password missing digit
    Given a password validator
    When I validate the password "NoNumbersHere!"
    Then the result should be invalid

Scenario: Password missing special character
    Given a password validator
    When I validate the password "MissingSpecial123"
    Then the result should be invalid