import { Box, useTheme } from "@material-ui/core";
import Header from "../../components/Header";
import React, { useEffect, useState } from 'react';
import { Bar, Doughnut } from 'react-chartjs-2';
import { AdvertisingСompany, RepairOrder, SalesStages } from "../../Type";
import dataProvider from "../../providers/dataProvider";
import { ChartData } from "chart.js";
import { CategoryScale } from 'chart.js';
import Chart from 'chart.js/auto';
import { tokens } from "../../theme";

Chart.register(
    CategoryScale
)
//const _header = Header("DASHBOARD", "Welcome to your dashboard");

const Dashboard = () => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const [salesStages, setSalesStages] = useState<SalesStages[]>([])
    const [advertisingСompany, setAdvertisingСompany] = useState<AdvertisingСompany[]>([])
    const [repairOrders, setRepairOrders] = useState<RepairOrder[]>([])
    const [salesStagesBig, setSalesStagesBig] = useState<SalesStages[]>([])
    const [chartData, setchartData] = useState<ChartData<"bar", (number | [number, number] | null)[], string>>({ labels: [''], datasets: [] })
    const [doughnutData, setDoughnutData] = useState<ChartData<"doughnut", (number | [number, number] | null)[], string>>({ labels: [''], datasets: [] })
    const [chartOrderData, setChartOrderData] = useState<ChartData<"bar", (number | [number, number] | null)[], string>>({ labels: [''], datasets: [] })
    useEffect(() => {
        dataProvider.getList<SalesStages>('salesstages')
            .then(value => {
                if (value.data) {
                    setSalesStages(value.data)
                    setchartData({
                        labels: value.data.map((value) => value.name), datasets: [{
                            label: 'Колличество заявок',
                            data: value.data.map(value => value.orders.length),
                            borderWidth: 2,
                            // borderColor: colors.grey[900],
                            // hoverBackgroundColor: colors.greenAccent[300],
                            // hoverBorderColor: colors.grey[500],
                            // backgroundColor: colors.primary[700]
                        }]
                    })
                }
            })

        dataProvider.getList<AdvertisingСompany>('chart/advertisingcompany')
            .then(value => {
                if (value.data) {
                    setAdvertisingСompany(value.data)
                    setDoughnutData({
                        labels: value.data.map((value) => value.name), datasets: [
                            {
                            label: 'Колличество заявок',
                            data: value.data.map(value => value.repairOrders?.length||0),
                            borderWidth: 2,
                            // borderColor: colors.grey[900],
                            // hoverBackgroundColor: colors.greenAccent[300],
                            // hoverBorderColor: colors.grey[500],
                            // backgroundColor: colors.primary[700]
                        }]
                    })
                }
            })

            dataProvider.getList<SalesStages>('chart/salesstages')
            .then(value => {
                if (value.data) {
                    setSalesStagesBig(value.data)
                    setChartOrderData({
                        labels: value.data.map((value) => value.name), datasets: [
                            {
                            label: 'Планируемая прибыль',
                            data: value.data.map(value => value.orders.reduce((sum, current) => sum + current.price, 0)),
                            borderWidth: 2,
                            // borderColor: colors.grey[900],
                            // hoverBackgroundColor: colors.greenAccent[300],
                            // hoverBorderColor: colors.grey[500],
                            // backgroundColor: colors.primary[700]
                        }]
                    })
                }
            })
    }, [])


    return <Box m={"20px"}>
        <Header title="DASHBOARD" subtitle="Welcome to your dashboard" />
        {/* <Box display={"flex"} justifyContent={"space-between"} alignItems={"center"} width={'100%'} height={'100%'} sx={{
            
            //fontWeight: '700',
            borderRadius: 22,
            p: 1,
            m: 1,
            bgcolor: colors.grey[900]
        }}> */}
        <Bar data={chartData} />
        <Bar data={chartOrderData} />
        <Box  width={'100%'} height={'100%'}>
        <Doughnut data={doughnutData}/>
        
        </Box>
        {/* </Box> */}
    </Box >
}

export default Dashboard;