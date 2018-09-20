var dfIndexVm = new Vue({
    el: '.df-index',
    components: {
        'draggable': draggable
    },
    data() {
        return {
            control: [

            ]
        }
    },
    methods: {
        getdata(evt) {
            console.log(evt.draggedContext.element.id)
        },
        datadragEnd(evt) {
            console.log('拖动前的索引 :' + evt.oldIndex)
            console.log('拖动后的索引 :' + evt.newIndex)
            console.log(this.tags)
        }
    },
})