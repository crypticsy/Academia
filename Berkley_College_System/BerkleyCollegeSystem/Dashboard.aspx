<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BerkleyCollegeSystem.WebForm7" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<div class="container-fluid p-0">

		<h1 class="h3 mb-5"><strong>Analytics</strong> Dashboard</h1>

		<div class="row">

			<div class="col-xl-6 col-xxl-5 d-flex">
				<div class="w-100">
					<div class="row">
						<div class="col-sm-6">
							<div class="card p-2">
								<div class="card-body">
									<div class="row">
										<div class="col mt-0">
											<h5 class="card-title text-sm">Total Student Count</h5>
										</div>

										<div class="col-auto">
											<div class="stat text-primary">
												<i class="align-middle" data-feather="users"></i>
											</div>
										</div>
									</div>
									<div class="d-flex">
										<h1 class="mt-1 mb-3" runat="server" ID="StudentCount"></h1>
										<h5 class="text-muted my-auto mx-3" style="opacity:0.5"> Students </h5>
									</div>
								</div>
							</div>

							<div class="card p-2">
								<div class="card-body">
									<div class="row">
										<div class="col mt-0">
											<h5 class="card-title text-sm">Total Teacher Count</h5>
										</div>

										<div class="col-auto">
											<div class="stat text-primary">
												<i class="align-middle" data-feather="briefcase"></i>
											</div>
										</div>
									</div>
									<div class="d-flex">
										<h1 class="mt-1 mb-3" runat="server" ID="TeacherCount"></h1>
										<h5 class="text-muted my-auto mx-3" style="opacity:0.5"> Teachers </h5>
									</div>
								</div>
							</div>

						</div>

						<div class="col-sm-6">
							<div class="card p-2">
								<div class="card-body">
									<div class="row">
										<div class="col mt-0">
											<h5 class="card-title text-sm">Total Module Count</h5>
										</div>

										<div class="col-auto">
											<div class="stat text-primary">
												<i class="align-middle" data-feather="book"></i>
											</div>
										</div>
									</div>
									<div class="d-flex">
										<h1 class="mt-1 mb-3" runat="server" ID="ModuleCount"></h1>
										<h5 class="text-muted my-auto mx-3" style="opacity:0.5"> Modules </h5>
									</div>
								</div>
							</div>

							<div class="card p-2">
								<div class="card-body">
									<div class="row">
										<div class="col mt-0">
											<h5 class="card-title text-sm">Total Building Count</h5>
										</div>

										<div class="col-auto">
											<div class="stat text-primary">
												<i class="align-middle" data-feather="home"></i>
											</div>
										</div>
									</div>
									<div class="d-flex">
										<h1 class="mt-1 mb-3" runat="server" ID="BuildingCount"></h1>
										<h5 class="text-muted my-auto mx-3" style="opacity:0.5"> Building </h5>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-6 col-xxl-7">
				<div class="card p-4 flex-fill w-100">
					<div class="row">
						<div class="col mt-0">
							<h5 class="card-title mb-0">Yearly Revenue</h5>
						</div>
						<div class="card-body py-4">
							<div class="chart chart-sm">
								<canvas id="chartjs-dashboard-line"></canvas>
							</div>
						</div>
					</div>
				</div>
			</div>

		</div>
		
		<div class="row">
			<div class="col-12 col-md-6 col-xxl-3 d-flex order-2 order-xxl-3">
				<div class="card p-4 flex-fill w-100">
					<div class="row">
						<div class="col mt-0">
						<h5 class="card-title mb-0">Gender Distribution</h5>
						</div>
						<div class="card-body d-flex">
							<div class="align-self-center w-100">
								<div class="py-3">
									<div class="chart chart-xs">
										<canvas id="chartjs-dashboard-pie"></canvas>
									</div>
									<table class="table mb-0 mt-4">
										<tbody>
											<%=GenderDistributionTable%>
										</tbody>
									</table>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div class="col-12 col-lg-8 col-xxl-9 d-flex">
				<div class="card p-4 flex-fill w-100">
					<div class="row">
						<div class="col mt-0">
							<h5 class="card-title mb-0">Top 5 Modules based on Student Distribution</h5>
						</div>
						<div class="card-body py-3">
							<div class="chart chart-sm">
								<canvas id="bar-chart-horizontal"></canvas>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

	</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptContent" runat="server">

	<script>
		document.addEventListener("DOMContentLoaded", function() {
			var ctx = document.getElementById("chartjs-dashboard-line").getContext("2d");
			var gradient = ctx.createLinearGradient(0, 0, 0, 225);
			gradient.addColorStop(0, "rgba(215, 227, 244, 1)");
			gradient.addColorStop(1, "rgba(215, 227, 244, 0)");
			// Line chart
			new Chart(document.getElementById("chartjs-dashboard-line"), {
				type: "line",
				data: {
					labels: <%=YearLabel%>,
					datasets: [{
						label: "Fee Collected (NPR.)",
						fill: true,
						backgroundColor: gradient,
						borderColor: window.theme.primary,
						data:  <%=Revenue%>,
					}]
				},
				options: {
					maintainAspectRatio: false,
					legend: {
						display: false
					},
					tooltips: {
						intersect: false
					},
					hover: {
						intersect: true
					},
					plugins: {
						filler: {
							propagate: false
						}
					},
					scales: {
						xAxes: [{
							reverse: true,
							gridLines: {
								color: "rgba(0,0,0,0.0)"
							},
							scaleLabel: {
								display: true,
								labelString: "Year"
							  }
						}],
						yAxes: [{
							ticks: {
								beginAtZero: true
							},
							display: true,
							borderDash: [3, 3],
							gridLines: {
								color: "rgba(0,0,0,0.0)"
							},
							offset: true,
							scaleLabel: {
								display: true,
								labelString: "Total Amount (NPR.)"
							  }
						}]
					}
				}
			});
		});
	</script>

	<script>
		document.addEventListener("DOMContentLoaded", function() {
			// Pie chart
			new Chart(document.getElementById("chartjs-dashboard-pie"), {
				type: "pie",
				data: {
					labels: <%=GenderLabels%>,
					datasets: [{
						data: <%=GenderDistribution%>,
						backgroundColor: [
							window.theme.primary,
							window.theme.warning,
							window.theme.danger
						],
						borderWidth: 5
					}]
				},
				options: {
					responsive: !window.MSInputMethodContext,
					maintainAspectRatio: false,
					legend: {
						display: false
					},
					cutoutPercentage: 65
				}
			});
		});
	</script>

	<script>
		document.addEventListener("DOMContentLoaded", function() {
			var ctx = document.getElementById("chartjs-dashboard-line").getContext("2d");
			var gradient = ctx.createLinearGradient(225, 225, 0, 0);
			gradient.addColorStop(0, "rgba(215, 227, 244, 1)");
			gradient.addColorStop(1, "rgba(255, 255, 255, 0)");
			// Horizontal bar chart
			new Chart(document.getElementById("bar-chart-horizontal"), {
				type: 'horizontalBar',
				data: {
				  labels: <%=ModuleLabels%>,
				  datasets: [
					{
					  label: "Total Students Enrolled",
					  fill: true,
					  backgroundColor: gradient,
					  borderColor: window.theme.primary,
					  data:  <%=ModuleDistribution%>,
					}
				  ]
				},
				options: {
					legend: { display: false },
					title: {
						display: true,
						text: 'Total Number of Students Enrolled'
					},
					hover: {
						intersect: true
					},
					plugins: {
						filler: {
							propagate: false
						}
					},
					scales: {
						xAxes: [{
							ticks: {
								beginAtZero: true
							},
							gridLines: {
								color: "rgba(0,0,0,0.0)"
							},
							scaleLabel: {
								display: true,
								labelString: "Year"
							  }
						}],
						yAxes: [{
							ticks: {
								beginAtZero: true
							},
							gridLines: {
								color: "rgba(0,0,0,0.0)"
							},
							scaleLabel: {
								display: true,
								labelString: "Modules"
							  }
						}]
					}
				}
			});
		});
	</script>

</asp:Content>