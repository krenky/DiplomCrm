import {
    Alert,
    AlertIcon,
    Button,
    Center,
    Container,
    FormControl,
    FormLabel,
    Heading,
    Input,
    Modal,
    ModalBody,
    ModalCloseButton,
    ModalContent,
    ModalFooter,
    ModalHeader,
    ModalOverlay,
    Select,
    Text,
    VStack,
    useDisclosure,
} from "@chakra-ui/react";
import { Calendar, CalendarDefaultTheme } from '@uselessdev/datepicker'//todo удалить пакет
import { FunctionComponent, useEffect, useState } from "react";
import { DatePicker } from 'chakra-ui-date-input'
import dataProvider from "../dataProvider";
import { AdvertisingСompany } from "../Type"
import { toast } from "./ToastManager";


interface HeroSectionProps { }

export default function HeroSection() {
    const { isOpen, onOpen, onClose } = useDisclosure()
    const [isOpenOldClient, setOpenOldClient] = useState<boolean>(false)
    const [dates, setDates,] = useState()
    const [FirstName, setFirstName] = useState("firstName");
    const [LastName, setLastName] = useState("lastName");
    const [Email, setEmail] = useState("Email");
    const [Address, setAddress] = useState("address");
    const [Birthdate, setBirthdate] = useState<Date>(new Date(Date.now()));
    const [PhoneModel, setPhoneModel] = useState("PhoneModel");
    const [Comment, setComment] = useState("Comment");
    const [Manufacturer, setManufacturer] = useState("Comment");
    const [advertisingСompany, setAdvertisingСompany] = useState<AdvertisingСompany[]>([]);
    const [pcode, setCode] = useState<string>('');

    const save = function onSaveOrder() {
        const now = new Date();
        if (Birthdate.getDate() == now.getDate() &&
            Birthdate.getMonth() == now.getMonth()) {
            alert('Поздравляем с днем рождения!!! для вас активирована скидка 15%')
        }
        fetch(`https://localhost:7270/api/landing/Landing`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain',
                'Access-Control-Allow-Origin': '*'
            },
            body: JSON.stringify({
                id: '0',
                firstName: FirstName,
                lastName: LastName,
                phone: '0',
                email: Email,
                birthdate: Birthdate,
                phoneModel: PhoneModel,
                comment: Comment,
                Manufacturer: Manufacturer,
                code: advertisingСompany.find(item => item.code == pcode)
            })
        })
            .then((data) => {
                console.log(data);
                onClose();
            })
            .catch((err) => {
                console.log(err.message);
            });
    }

    const saveOldClient = function onSaveOrder() {
        fetch(`https://localhost:7270/api/landing/Landing/registerold`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain',
                'Access-Control-Allow-Origin': '*'
            },
            body: JSON.stringify({
                id: '0',
                phone: '0',
                email: Email,
                phoneModel: PhoneModel,
                comment: Comment,
                Manufacturer: Manufacturer,
                code: advertisingСompany.find(item => item.code == pcode)
            })
        })
            .then((data) => {
                console.log(data);
                onClose();
            })
            .catch((err) => {
                console.log(err.message);
            });
    }

    const GetIsBirthdate = async function onSaveOrder(_email: string): Promise<boolean> {
        let res: boolean = false;
        return await fetch(`https://localhost:7270/api/landing/Landing/getbirthday?email=` + _email, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain',
                'Access-Control-Allow-Origin': '*'
            }
        })
            .then((data) => {
                return data.json() as unknown as boolean;
            })
            .catch((err) => {
                console.log(err.message);
                return false;
            });
        return res;
    }

    useEffect(() => {
        dataProvider.getList<AdvertisingСompany>('AdvertisingСompany')
            .then(result => setAdvertisingСompany(result.data || []))
    }, []);

    function switchIsOpenOldClient() {
        setOpenOldClient(!isOpenOldClient);
    }

    return (
        <Container maxW="container.lg">
            <Center p={4} minHeight="70vh">
                <VStack>
                    <Container maxW="container.md" textAlign="center">
                        <Heading size="2xl" mb={4} color="gray.700">
                            Сломался телефон?
                        </Heading>

                        <Text fontSize="xl" color="gray.500">
                            Починим вашу технику за 1 день
                        </Text>

                        <Button
                            mt={8}
                            colorScheme="brand"
                            onClick={onOpen}
                        >
                            Заполнить заявку →
                        </Button>



                        <Text my={2} fontSize="sm" color="gray.500">
                            1000+ ремонтов каждый день по всей России
                        </Text>
                        <Button
                            mt={8}
                            colorScheme="brand"
                            variant={"ghost"}
                            onClick={switchIsOpenOldClient}
                        >
                            Уже были у нас? →
                        </Button>

                        <Modal
                            isOpen={isOpen}
                            onClose={onClose}
                        >
                            <ModalOverlay />
                            <ModalContent>
                                <ModalHeader>Регистрация заявки</ModalHeader>
                                <ModalCloseButton />
                                <ModalBody pb={6}>
                                    <FormControl>
                                        <FormLabel>Имя</FormLabel>
                                        <Input placeholder='Сергей' name="FirstName"
                                            onBlur={evt => setFirstName(evt.target.value)} />
                                    </FormControl>

                                    <FormControl mt={4}>
                                        <FormLabel>Фамилия</FormLabel>
                                        <Input placeholder='Назаров' name="LastName"
                                            onBlur={evt => setLastName(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>email</FormLabel>
                                        <Input placeholder='nazaroff.serezha2014@gmail.com'
                                            name="Email"
                                            onBlur={evt => setEmail(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>День рождения</FormLabel>
                                        <DatePicker
                                            placeholder='Введите ваш день рождения'
                                            name='Birthdate'
                                            dateFormat='DD/MM/YYYY'
                                            onChange={(date: string) => console.log(date)}
                                            onBlur={evt => {
                                                let date = new Date(evt.target.value);
                                                let now = new Date();
                                                setBirthdate(new Date(evt.target.value))
                                                if (date.getDate() == now.getDate() &&
                                                    date.getMonth() == now.getMonth()) {
                                                    alert('Поздравляем с днем рождения!!! для вас активирована скидка 15%')
                                                }
                                            }
                                            }
                                        />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Производитель</FormLabel>
                                        <Select placeholder='Select option' onBlur={evt => setManufacturer(evt.target.value)}>
                                            <option value='Apple'>Apple</option>
                                            <option value='Samsung'>Samsung</option>
                                            <option value='Meizu'>Meizu</option>
                                            <option value='OnePlus'>OnePlus</option>
                                            <option value='Oppo'>Oppo</option>
                                            <option value='Sony'>Sony</option>
                                            <option value='Yotaphone'>Yotaphone</option>
                                            <option value='Asus'>Asus</option>
                                        </Select>
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Модель смартфона</FormLabel>
                                        <Input placeholder='iphone s6' name="PhoneModel"
                                            onBlur={evt => setPhoneModel(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Опишите поломку</FormLabel>
                                        <Input placeholder='Комментарий' name="Comment"
                                            onBlur={evt => setComment(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Промокод</FormLabel>
                                        <Input placeholder='код' name="code"
                                            onBlur={evt => {
                                                setCode(evt.target.value)
                                                const comp: AdvertisingСompany | undefined = advertisingСompany.find(value => value.code == pcode)
                                                toast.show({
                                                    title: 'Скидка активирована',
                                                    content: 'Скидка в размере ' + comp?.discount + ' процентов',
                                                    duration: 3000
                                                })
                                            }} />
                                    </FormControl>
                                </ModalBody>

                                <ModalFooter>
                                    <Button colorScheme='blue' mr={3}
                                        onClick={save}>
                                        Save
                                    </Button>
                                    <Button onClick={onClose}>Cancel</Button>
                                </ModalFooter>
                            </ModalContent>
                        </Modal>

                        <Modal
                            isOpen={isOpenOldClient}
                            onClose={switchIsOpenOldClient}
                        >
                            <ModalOverlay />
                            <ModalContent>
                                <ModalHeader>Регистрация заявки</ModalHeader>
                                <ModalCloseButton />
                                <ModalBody pb={6}>
                                    <FormControl mt={4}>
                                        <FormLabel>email</FormLabel>
                                        <Input placeholder='nazaroff.serezha2014@gmail.com'
                                            name="Email"
                                            onBlur={evt => {
                                                setEmail(evt.target.value)
                                                //GetIsBirthdate(evt.target.value);
                                                GetIsBirthdate(evt.target.value)
                                                    .then(value => {
                                                        if (value)
                                                            alert('Поздравляем с днем рождения!!! для вас активирована скидка 15%')
                                                    })
                                            }} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Производитель</FormLabel>
                                        <Select placeholder='Select option' onBlur={evt => setManufacturer(evt.target.value)}>
                                            <option value='Apple'>Apple</option>
                                            <option value='Samsung'>Samsung</option>
                                            <option value='Meizu'>Meizu</option>
                                            <option value='OnePlus'>OnePlus</option>
                                            <option value='Oppo'>Oppo</option>
                                            <option value='Sony'>Sony</option>
                                            <option value='Yotaphone'>Yotaphone</option>
                                            <option value='Asus'>Asus</option>
                                        </Select>
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Модель</FormLabel>
                                        <Input placeholder='iphone s6' name="PhoneModel"
                                            onBlur={evt => setPhoneModel(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Опишите поломку</FormLabel>
                                        <Input placeholder='Комментарий' name="Comment"
                                            onBlur={evt => setComment(evt.target.value)} />
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Промокод</FormLabel>
                                        <Input placeholder='код' name="code"
                                            onBlur={evt => {
                                                setCode(evt.target.value)
                                                const comp: AdvertisingСompany | undefined = advertisingСompany.find(value => value.code == pcode)
                                                if (comp)
                                                    toast.show({
                                                        title: 'Скидка активирована',
                                                        content: 'Скидка в размере ' + comp?.discount + ' процентов',
                                                        duration: 3000
                                                    })
                                            }} />
                                    </FormControl>
                                </ModalBody>

                                <ModalFooter>
                                    <Button colorScheme='blue' mr={3}
                                        onClick={saveOldClient}>
                                        Save
                                    </Button>
                                    <Button onClick={switchIsOpenOldClient}>Cancel</Button>
                                </ModalFooter>
                            </ModalContent>
                        </Modal>
                    </Container>
                </VStack>
            </Center>
        </Container>
    );
}


export const ModalNewClient = (props: { isOpen: boolean, onClose: () => void }) => {

}
