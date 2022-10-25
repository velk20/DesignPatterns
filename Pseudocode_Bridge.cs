// "Абстракцията" дефинира интерфейса за "контрола"
// част от двете йерархии на класове. Поддържа справка
// към обект от йерархията на "имплементиране" и делегира
// цялата реална работа за този обект.
class RemoteControl is
    protected field device: Device
    constructor RemoteControl(device: Device) is
        this.device = device
    method togglePower() is
        if (device.isEnabled()) then
            device.disable()
        else
            device.enable()
    method volumeDown() is
        device.setVolume(device.getVolume() - 10)
    method volumeUp() is
        device.setVolume(device.getVolume() + 10)
    method channelDown() is
        device.setChannel(device.getChannel() - 1)
    method channelUp() is
        device.setChannel(device.getChannel() + 1)


// Можете да разширите класове от йерархията на абстракцията
// независимо от класовете устройства.
class AdvancedRemoteControl extends RemoteControl is
    method mute() is
        device.setVolume(0)


// Интерфейсът "implementation" декларира методи, общи за всички
// конкретни класове за изпълнение. Не е задължително да съвпада с
// интерфейс на абстракцията. Всъщност двата интерфейса могат да бъдат
// напълно различно. Обикновено интерфейсът за изпълнение
// осигурява само примитивни операции, докато абстракцията
// дефинира операции от по-високо ниво въз основа на тези примитиви.
interface Device is
    method isEnabled()
    method enable()
    method disable()
    method getVolume()
    method setVolume(percent)
    method getChannel()
    method setChannel(channel)


// Всички устройства следват един и същ интерфейс.
class Tv implements Device is
    // ...

class Radio implements Device is
    // ...


// Клиентсия код
tv = new Tv()
remote = new RemoteControl(tv)
remote.togglePower()

radio = new Radio()
remote = new AdvancedRemoteControl(radio)