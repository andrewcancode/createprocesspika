# createprocesspika

This is C# code for creating a binary that emulates some of the early stage discovery commands launched by the Pikabot malware after it has unpacked and injected itself into it's target system binary (in the case being studied, this would be SearchProtocolHost.exe).

See https://tria.ge/231117-vgd72abd46/behavioral1 for example

Once compiled, this executable will first check whether it is being debugged, and if not it will proceed with launching child processes to gather system info and report to stdout.  This can be used for designing tests in your environment to see what the corresponding endpoint telemetry looks like and whether your EDR natively would flag on this or, if not, will show you what you need to do to build a detection.

Further inspiration for this project comes from the following Sigma rule by Florian Roth: Whoami.EXE Execution Anomaly
https://detection.fyi/sigmahq/sigma/windows/process_creation/proc_creation_win_whoami_parent_anomaly/
