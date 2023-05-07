import {
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
    Text,
    VStack,
    useDisclosure,
} from "@chakra-ui/react";
import { Calendar, CalendarDefaultTheme } from '@uselessdev/datepicker'//todo удалить пакет
import { FunctionComponent, useState } from "react";
import { DatePicker } from 'chakra-ui-date-input'


interface HeroSectionProps { }

export default function HeroSection() {
    const { isOpen, onOpen, onClose } = useDisclosure()
    const [dates, setDates] = useState()
    const [FirstName, setFirstName] = useState("firstName");
    const [LastName, setLastName] = useState("lastName");
    const [Email, setEmail] = useState("Email");
    const [Address, setAddress] = useState("address");
    const [Birthdate, setBirthdate] = useState<Date>(new Date(Date.now()));
    const [PhoneModel, setPhoneModel] = useState("PhoneModel");
    const [Comment, setComment] = useState("Comment");

    const save = function onSaveOrder(){
        fetch(`https://localhost:7270/api/landing/Landing`,{
            method: "POST",
            headers: { 'Content-Type': 'application/json',
                        'accept': 'text/plain',
                        'Access-Control-Allow-Origin': '*' },
            body: JSON.stringify({
                id: '0',
                firstName: FirstName,
                lastName: LastName,
                phone: '0',
                email: Email,
                address: Address,
                birthdate: Birthdate,
                phoneModel: PhoneModel,
                comment: Comment
            })
        })
        .then((data) => {
            console.log(data);
        })
        .catch((err) => {
            console.log(err.message);
         });
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
                                        onBlur={evt => setFirstName(evt.target.value)}/>
                                    </FormControl>

                                    <FormControl mt={4}>
                                        <FormLabel>Фамилия</FormLabel>
                                        <Input placeholder='Назаров' name="LastName" 
                                        onBlur={evt => setLastName(evt.target.value)}/>
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>email</FormLabel>
                                        <Input placeholder='nazaroff.serezha2014@gmail.com'
                                        name="Email"
                                        onBlur={evt => setEmail(evt.target.value)}/>
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>Адресс</FormLabel>
                                        <Input placeholder='Казань Чистопльская 40\50' 
                                        name="Address" 
                                        onBlur={evt => setAddress(evt.target.value)}/>
                                    </FormControl>
                                    <FormControl mt={4}>
                                        <FormLabel>День рождения</FormLabel>
                                        <DatePicker
                                            placeholder='Введите ваш день рождения'
                                            name='Birthdate'
                                            dateFormat='DD/MM/YYYY'
                                            onChange={(date: string) => console.log(date)}
                                            onBlur={evt => setBirthdate(new Date(evt.target.value))}
                                        />
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
                    </Container>
                </VStack>
            </Center>
        </Container>
    );
}
function onSaveOrder(){
    fetch(`https://localhost:7270/`,{
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({firstName: FirstName})
    })
    .then()
}
