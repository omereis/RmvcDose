# RmvcDose
## Displays [RMVC](https://www.rotem-radiation.co.il/service2/rotem-meter-view-3000/) Rate, Dose, and Calculated Dose
### Basic Operation
This softare reads data generated by Rotms's RMVC software, saved to CSV file.
The data is parsed and displayed in a table.
Clicking `Parse` button will display rate, accumulated dose, and calculated dose, on charts in 2 tabs.
### Calculating Dose
The accumulated dose at a time _n_, _CalcDose_(_n_), is  
CalcDose(n) = CalcDose(n-1) + Rate(n) * dt / 3600
