import { useEffect, useState } from "react";
import { Sidebar, Menu, MenuItem, useProSidebar } from "react-pro-sidebar";
import { Box, IconButton, Typography, useTheme } from "@mui/material";
import { Link } from "react-router-dom";
//import "react-pro-sidebar/dist/css/styles.css";
import { tokens } from "../../theme";
//#region Иконки
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import PeopleOutlinedIcon from "@mui/icons-material/PeopleOutlined";
import ContactsOutlinedIcon from "@mui/icons-material/ContactsOutlined";
import ReceiptOutlinedIcon from "@mui/icons-material/ReceiptOutlined";
import PersonOutlinedIcon from "@mui/icons-material/PersonOutlined";
import CalendarTodayOutlinedIcon from "@mui/icons-material/CalendarTodayOutlined";
import HelpOutlineOutlinedIcon from "@mui/icons-material/HelpOutlineOutlined";
import BarChartOutlinedIcon from "@mui/icons-material/BarChartOutlined";
import PieChartOutlineOutlinedIcon from "@mui/icons-material/PieChartOutlineOutlined";
import TimelineOutlinedIcon from "@mui/icons-material/TimelineOutlined";
import MenuOutlinedIcon from "@mui/icons-material/MenuOutlined";
import MapOutlinedIcon from "@mui/icons-material/MapOutlined";
import AddIcon from '@mui/icons-material/Add';
import dataProvider from "../../providers/dataProvider";
import { getIdentity } from "../../providers/authProvider";
import InventoryIcon from '@mui/icons-material/Inventory';
//#endregion

interface ItemProps {
    title: string;
    to: string;
    icon: JSX.Element;
    selected: string;
    setSelected: React.Dispatch<React.SetStateAction<string>>;
}

const Item: React.FC<ItemProps> = ({ title, to, icon, selected, setSelected }) => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    return (
        <MenuItem
            active={selected === title}
            style={{
                color: colors.grey[100],
            }}
            onClick={() => setSelected(title)}
            icon={icon}
        >
            <Typography>{title}</Typography>
            <Link to={to} />
        </MenuItem>
    );
};

const SideBar: React.FC = () => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const [isCollapsed, setIsCollapsed] = useState<boolean>(false);
    const [selected, setSelected] = useState<string>("Dashboard");
    const [currentUser, setCurrentUser] = useState<{
        id: string;
        fullName: string;
        email: string;
    }>();

    useEffect(() => {

        getIdentity()
            .then((value) => setCurrentUser(value))
            .catch(/*() => document.location = 'http://localhost:5173/login'*/)
    })

    const { collapseSidebar } = useProSidebar();
    function collapse() {
        setIsCollapsed(!isCollapsed);
        collapseSidebar(!isCollapsed);
    }

    return (
        <Box
            sx={{
                "& .pro-sidebar-inner": {
                    background: `${colors.primary[400]} !important`,
                },
                "& .pro-icon-wrapper": {
                    backgroundColor: "transparent !important",
                },
                "& .pro-inner-item": {
                    padding: "5px 35px 5px 20px !important",
                },
                "& .pro-inner-item:hover": {
                    color: "#868dfb !important",
                },
                "& .pro-menu-item.active": {
                    color: "#6870fa !important",
                },
            }}
        >
            <Sidebar>
                <Menu>
                    {/* LOGO AND MENU ICON */}
                    <MenuItem
                        onClick={() => collapse()}
                        icon={isCollapsed ? <MenuOutlinedIcon /> : undefined}
                        style={{
                            margin: "10px 0 20px 0",
                            color: colors.grey[100],
                        }}
                    >
                        {!isCollapsed && (
                            <Box
                                display="flex"
                                justifyContent="space-between"
                                alignItems="center"
                                ml="15px"
                            >
                                <Typography variant="h3" color={colors.grey[100]}>
                                    Меню
                                </Typography>
                                <IconButton onClick={() => collapse()}>
                                    <MenuOutlinedIcon />
                                </IconButton>
                            </Box>
                        )}
                    </MenuItem>

                    {!isCollapsed && (
                        <Box mb="25px">
                            <Box display="flex" justifyContent="center" alignItems="center">
                                <img
                                    alt="profile-user"
                                    width="100px"
                                    height="100px"
                                    src={`../../assets/user.png`}
                                    style={{ cursor: "pointer", borderRadius: "50%" }}
                                />
                            </Box>
                            <Box textAlign="center">
                                <Typography
                                    variant="h2"
                                    color={colors.grey[100]}
                                    fontWeight="bold"
                                    sx={{ m: "10px 0 0 0" }}
                                >
                                    {currentUser ? currentUser.fullName : ''}
                                </Typography>
                                <Typography variant="h5" color={colors.greenAccent[100]}>
                                    Сергей Назаров
                                </Typography>

                            </Box>
                        </Box>
                    )}

                    <Box paddingLeft={isCollapsed ? undefined : "10%"}>

                        <MenuItem component={<Link to="/team" />} icon={<PeopleOutlinedIcon />}>Сотрудники</MenuItem>
                        <MenuItem component={<Link to="/team/add" />} icon={<AddIcon />}>Регистр. сотрдника</MenuItem>
                        <MenuItem component={<Link to="/calendar" />} icon={<CalendarTodayOutlinedIcon />}>Календарь</MenuItem>
                        <MenuItem component={<Link to="/repairorders" />} icon={<ReceiptOutlinedIcon />}>Заявки</MenuItem>
                        <MenuItem component={<Link to="/сustomers" />} icon={<ContactsOutlinedIcon />}>Клиенты</MenuItem>
                        <MenuItem component={<Link to="/сustomers/add" />} icon={<AddIcon />}>Регистр. клиентов</MenuItem>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <MenuItem component={<Link to="/team" />} icon={<PeopleOutlinedIcon />}>Сотрудники</MenuItem>
                        <MenuItem component={<Link to="/team/add" />} icon={<AddIcon />}>Регистр. сотрдника</MenuItem>
                        <MenuItem component={<Link to="/calendar" />} icon={<CalendarTodayOutlinedIcon />}>Календарь</MenuItem>
                        <MenuItem component={<Link to="/repairorders" />} icon={<ReceiptOutlinedIcon />}>Заявки</MenuItem>
                        <MenuItem component={<Link to="/сustomers" />} icon={<ContactsOutlinedIcon />}>Клиенты</MenuItem>
                        <MenuItem component={<Link to="/сustomers/add" />} icon={<AddIcon />}>Регистр. клиентов</MenuItem>
                        <Item
                            title="Contacts Information"
                            to="/contacts"
                            icon={<ContactsOutlinedIcon />}
                            selected={selected}
                            setSelected={setSelected}
                        />
                        <Item
                            title="Invoices Balances"
                            to="/invoices"
                            icon={<ReceiptOutlinedIcon />}
                            selected={selected}
                            setSelected={setSelected}
                        />

                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>
                        <Typography
                            variant="h6"
                            color={colors.grey[300]}
                            sx={{ m: "15px 0 5px 20px" }}
                        >
                            -
                        </Typography>

                    </Box>
                </Menu>
            </Sidebar>
        </Box>
    );
};

export default SideBar;