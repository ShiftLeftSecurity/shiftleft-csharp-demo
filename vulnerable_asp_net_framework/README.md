# About

This is a vulnerable ASP .net framework application that implements all
vulnerabilities listed in [OWASP's Top 10](https://www.owasp.org/index.php/Category:OWASP_Top_Ten_Project)
as small web programs. For every web program, we provide an exploit
int the [exploits subdirectory](./exploits)
that documents how the vulnerability can be actually exploited.

# OWASP top 10 (2017)

At the moment, we have implemented the following vulnerabilities.

### A1 -Injection
- [x] SQL Injection
- [x] XPATH Injection
### A2 -Broken Authentication
- [x] Credential Stuffing
### A3 -Sensitive Data Exposure
- [x] Leaking Credit Card Information
### A4 -XML External Entities (XXE)
- [x] Accessing local resource
### A5 -Broken Access Control
- [x] Elevate access privileges
### A6 -Security Misconfiguration
- [x] Show SQL Exception in response
### A7 -Cross-Site Scripting (XSS)
- [x] Reflected XSS
### A8 -Insecure Deserialization
- [x] Insecure XML deserialization
### A9 -Using Components with Known Vulnerabilities
- [x] Using component vulnerable to XSS
### A10 -Insufficient Logging&Monitoring
- [x] Insufficient logging after data breach
### A11 -Path Traversal
- [x] Path / directory traversal

# Preliminaries

The following instructions are based on the assumption that you are using
Microsoft Windows and that you have [Cygwin](https://www.cygwin.com/) installed.
We will port all the scripts to powershell so that they can be run natively
soon.

We also assume that you have installed `csharp2cpg`, `cpg2sp` and `sl`.

# Installation

The easiest way to setup the .net framework application is to import it into a
C# IDE (e.g., [Microsoft VS Community
Edition](https://visualstudio.microsoft.com/vs/community/)).  You can build and
run the application from within the IDE; you can import the project with
`File->Open->Project` and by selecting the `.sln` solution file. After that you
can right click on `Solution vulnerable_asp_net_framework` in the `Solution
Explorer` and select `Build Solution`.

For running the application, you can right-click on one of the `.aspx` files in
the `Solution Explorer` and select `View in Browser (Microsoft Edge)`. After
that you should be able to see the corresponding HTML mask in your browser.

After the application is up and running, you can run all the exploits by
executing the `run_all.sh` script in the `exploits/` directory with. The script
should produce the following output:

```bash
execute ./sqlinjection.sh ... OK
execute ./xss.sh ... OK
execute ./vulnerable_component.sh ... OK
execute ./broken_authentication.sh ... OK
execute ./insecure_deserialization.sh ... OK
execute ./security_misconfiguration.sh ... OK
execute ./xxe.sh ... OK
execute ./common.sh ... OK
execute ./xpathinjection.sh ... OK
execute ./broken_access_control.sh ... OK
execute ./insufficient-logging.sh ... OK
execute ./sensitive_data_exposure.sh ... OK
```

You can consider the `./run_all.sh` script as a sanity check that you can
execute to verify that your setup works correctly.

### Running Scripts against IIS on Windows
There is a sub-directory of the `exploits` directory called `iis_cmd_files` that contains scripts that can be run in a Windows terminal. All of these scripts work against the `vulnerable_asp_net_framework` application running in full IIS, using a local virtual directory named `vulnerable_asp_net_framework`.

# Howto find the vulnerabilities

## CPG Generation

After successfully setting up `csharp2cpg`, you can obtain the CPG
(in this example named `hsl.bin.zip`) of our vulnerable ASP .net framework application by executing the command below.

```bash
csharp2cpg.exe -i vulnerable_asp_net_framework/vulnerable_asp_net_framework.csproj -o hsl.bin.zip
```

The CPG that corresponds `vulnerable_asp_net_framework.csproj` is made available [here](https://drive.google.com/open?id=1952baucCxOu6fkKSncVRo2Ku5hX3H_wp).

## SP Generation

After successfully setting up `cpg2sp`, you can obtain the SP (in this example named `lm.sp`) of
our vulnerable ASP .net framework application by executing the command below.

The `base.policy` file is available [here](https://drive.google.com/open?id=1d_90dzHDx3swA1-x4lpUOcHqjiJca6j2).

You can put the `base.policy` file in your policy directory (e.g., `$HOME/.shiftleft/policy/static/com/hsl`).

```bash
./cpg2sp.sh --cpg hsl.bin.zip -o lm.sp --platform csharp --overlay -p $HOME/.shiftleft/policy/static/com/hsl/base.policy
```

## Loading the SP in ocular 

For displaying the vulnerabilities in ocular you can execute the following
commands.


```bash
./ocular.sh

 ██████╗  ██████╗██╗   ██╗██╗      █████╗ ██████╗
██╔═══██╗██╔════╝██║   ██║██║     ██╔══██╗██╔══██╗
██║   ██║██║     ██║   ██║██║     ███████║██████╔╝
██║   ██║██║     ██║   ██║██║     ██╔══██║██╔══██╗
╚██████╔╝╚██████╗╚██████╔╝███████╗██║  ██║██║  ██║
 ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝
//...
ocular> loadCpgWithOverlays("hsl.bin.zip","lm.sp")
ocular> cpg.finding.p
res21: List[String] = List(
// ...  
"""------------------------------------
Title: Sensitive data contained in HTTP request/response via `creditCard` in `SensitiveDataExposure.Page_Load`
Score: 2
Categories: [a6-sensitive-data-exposure]
Flow ids: [26678]
Description: Sensitive data included in HTTP request/response. This could result in sensitive data exposure. Many web applications and APIs do not properly protect sensitive data, such as financial and healthcare. Attackers may steal or modify such weakly protected data to conduct credit card fraud, identity theft, or other crimes.
## Countermeasures
//...
```

## Obtain analysis results on the dashboard

As a prerequisite for uploading the CPG to the dashboard, you need to setup the
[shiftleft cli](https://docs.shiftleft.io/shiftleft/getting-started/using-sl-the-shiftleft-cli).

You can run the analysis in the dashboard by executing the command below.

``` bash
./sl analyze --wait --policy com.hslNet/base --cpgupload --csharp --app HSLCSFW --force hsl.bin.zip
```

After launching the command above, you should be able to see output similar to
the one in the excerpt below. At the bottom of the excerpt you will find a URL
that you can paste in the address bar of your browser. After doing so, you will
be directed to the dashboard that contains the findings. You can find a
screenshot that illustrates what you should see in your dashboard below.

``` bash
Using Org ID found in local configuration file
Using Upload Token found in local configuration file
Uploading...

 84.39 KB / 84.39 KB [=================================================================] 100.00% 253.40 KB/s 0s

Saved config to shiftleft.json
... Done. Submitted for analysis
Waiting for analysis to finish. Press ctrl+c to cancel.
Progress: 15%
Progress: 15%
Progress: 16%
Progress: 30%
Progress: 31%
Progress: 90%
Progress: 91%
Progress: 100%
Done. Load the following URL in your browser:
https://www.stg.shiftleft.io/apps/HSLCSFW?organizationId=9494677f-8bdf-460f-afff-7ac09275e2a9
```
![Screenshot](https://github.com/ShiftLeftSecurity/testdata/blob/master/csharp/vulnerable_asp_net_framework/img/hsl.png "Dashboard Results")
