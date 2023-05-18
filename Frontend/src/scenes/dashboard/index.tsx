import { Box } from "@material-ui/core";
import Header from "../../components/Header";

//const _header = Header("DASHBOARD", "Welcome to your dashboard");

const Dashboard = () => {
    return <Box m={"20px"}>
        <Box display={"flex"} justifyContent={"space-between"} alignItems={"center"}>
            <Header title="DASHBOARD" subtitle="Welcome to your dashboard" />
        </Box>
    </Box >
}

export default Dashboard;