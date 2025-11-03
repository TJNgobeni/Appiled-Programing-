# Disaster Relief App - Load Testing

## Overview
This directory contains load and stress tests for the Disaster Relief Application using Apache JMeter.

## Test Scenarios

### 1. Load Test (50 Concurrent Users)
- **Objective**: Test application performance under expected peak load
- **Users**: 50 concurrent users
- **Duration**: 5 iterations per user
- **Ramp-up**: 120 seconds
- **Pages Tested**: 
  - Home Page (/)
  - Create Incident Page (/Home/CreateIncidentReport)
  - Volunteer Registration (/Home/VolunteerRegistration)

### 2. Stress Test (150 Concurrent Users)
- **Objective**: Identify application breaking points
- **Users**: 150 concurrent users  
- **Duration**: 3 iterations per user
- **Ramp-up**: 60 seconds
- **Scenario**: Multiple users submitting incident reports simultaneously

## How to Run

### Prerequisites
1. Install Apache JMeter from https://jmeter.apache.org/
2. Ensure your Disaster Relief App is running on http://localhost:5000

### Running Tests

#### Windows:
```cmd
cd LoadTests
run-load-test.bat